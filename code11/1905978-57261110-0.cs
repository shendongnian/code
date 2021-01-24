    public async Task<Result> UpdateAsync(
                T document, 
                string indexName = null, 
                string typeName = null,
                Refresh? refresh = null, 
                CancellationToken cancellationToken = default)
            {
                Guard.Argument(document, nameof(document)).NotNull();
    
                await RemoveNullFieldsFromDocumentAsync(document, document.Id, indexName, typeName, cancellationToken);
    
                var response = await Client.UpdateAsync<T, object>(
                    document.Id, 
                    u => u.Doc(document)
                        .Index(indexName ?? DocumentMappings.IndexStrategy)
                        .Type(typeName ?? DocumentMappings.TypeName)
                        .Refresh(refresh), 
                    cancellationToken);
                
                var errorMessage = response.LogResponseIfError(_logger);
                
                return errorMessage.IsNullOrEmpty() ? Result.Ok() : Result.Fail(errorMessage);
            }
            
            public async Task<Result> UpdateAsync(
                string id, 
                object partialDocument, 
                string indexName = null, 
                string typeName = null,
                Refresh? refresh = null, 
                CancellationToken cancellationToken = default)
            {
                Guard.Argument(partialDocument, nameof(partialDocument)).NotNull();
                Guard.Argument(id, nameof(id)).NotNull().NotEmpty().NotWhiteSpace();
                
                await RemoveNullFieldsFromDocumentAsync(partialDocument, id, indexName, typeName, cancellationToken);
    
                var response = await Client.UpdateAsync<T, object>(
                    id, 
                    u => u.Doc(partialDocument)
                        .Index(indexName ?? DocumentMappings.IndexStrategy)
                        .Type(typeName ?? DocumentMappings.TypeName)
                        .Refresh(refresh), 
                    cancellationToken);
                
                var errorMessage = response.LogResponseIfError(_logger);
                
                return errorMessage.IsNullOrEmpty() ? Result.Ok() : Result.Fail(errorMessage);
            }
    
            private async Task<Result> RemoveNullFieldsFromDocumentAsync(
                object document,
                string documentId,
                string indexName = null, 
                string typeName = null,
                CancellationToken cancellationToken = default)
            {
                var result = Result.Ok();
                var allNullProperties = GetNullPropertyValueNames(document);
                if (allNullProperties.AnyAndNotNull())
                {
                    var script = allNullProperties.Select(p => $"ctx._source.remove('{p}')").Aggregate((p1, p2) => $"{p1}; {p2};");
                    result = await UpdateByQueryIdAsync(
                                                    documentId, 
                                                    script,
                                                    indexName,
                                                    typeName,
                                                    cancellationToken: cancellationToken);
                }
    
                return result;
            }
            
            private static IReadOnlyList<string> GetNullPropertyValueNames(object document)
            {
                var allPublicProperties =  document.GetType().GetProperties().ToList();
                    
                var allObjects = allPublicProperties.Where(pi => pi.PropertyType.IsClass).ToList();
                
                var allNames = new List<string>();
    
                foreach (var propertyInfo in allObjects)
                {
                    if (propertyInfo.PropertyType == typeof(string))
                    {
                        var isNullOrEmpty = ((string) propertyInfo.GetValue(document)).IsNullOrEmpty();
                        if (isNullOrEmpty)
                        {
                            allNames.Add(propertyInfo.Name.ToCamelCase());
                        }
                    }
                    else if (propertyInfo.PropertyType.IsClass)
                    {
                        if (propertyInfo.GetValue(document).IsNotNull())
                        {
                            var namesWithobjectName = GetNullPropertyValueNames(propertyInfo.GetValue(document))
                                .Select(p => $"{propertyInfo.PropertyType.Name.ToCamelCase()}.{p.ToCamelCase()}");
                            allNames.AddRange(namesWithobjectName);
                        }
                    }
                }
                
                return allNames;
            }
    
            public async Task<Result> UpdateByQueryIdAsync(
                string documentId,
                string script,
                string indexName = null, 
                string typeName = null, 
                bool waitForCompletion= false,
                CancellationToken cancellationToken = default)
            {
                Guard.Argument(documentId, nameof(documentId)).NotNull().NotEmpty().NotWhiteSpace();
                Guard.Argument(script, nameof(script)).NotNull().NotEmpty().NotWhiteSpace();
    
                var response = await Client.UpdateByQueryAsync<T>(
                    u => u.Query(q => q.Ids(i => i.Values(documentId)))
                            .Conflicts(Conflicts.Proceed)
                            .Script(s => s.Source(script))
                            .Refresh()
                            .WaitForCompletion(waitForCompletion)
                            .Index(indexName ?? DocumentMappings.IndexStrategy)
                            .Type(typeName ?? DocumentMappings.TypeName), 
                    cancellationToken);
                
                var errorMessage = response.LogResponseIfError(_logger);
                
                return errorMessage.IsNullOrEmpty() ? Result.Ok() : Result.Fail(errorMessage);
            }
