     var request = WebRequest.CreateHttp(baseUrl + "$metadata");
                var settings = new ODataMessageReaderSettings() { MessageQuotas = new ODataMessageQuotas() { MaxReceivedMessageSize = 35000000 } };
                var metadataMessage = new ClientHttpResponseMessage((HttpWebResponse)request.GetResponse());
                using (var messageReader = new ODataMessageReader(metadataMessage, settings))
                {
                    IEdmModel edmModel = messageReader.ReadMetadataDocument();
                    foreach (var entity in edmModel.EntityContainer.EntitySets())
                    {
                        string entityName = entity.Name; // entity name
                        IEdmCollectionType edmCollectionType = (IEdmCollectionType)entity.Type;
                        IEdmType edmType = edmCollectionType.ElementType.Definition;
                        IEdmStructuredType edmStructuredType = edmType as IEdmStructuredType;
                        foreach (IEdmProperty property in edmStructuredType.DeclaredProperties)
                        {
                            string propertyName = property.Name;
                            IEdmType edmType2 = property.Type.Definition;
                            var primitive = edmType2 as IEdmPrimitiveType;
                            string elementName = primitive.Name;
                        }
                    }
                        
                }
