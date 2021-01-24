        private EntityMetadata GetEntityMetadata(string entityName, EntityFilters entityFilters, bool retrieveAsIfPublished = false)
        {
            var request = new RetrieveEntityRequest
            {
                EntityFilters = entityFilters,
                LogicalName = entityName,
                RetrieveAsIfPublished = retrieveAsIfPublished,
            };
            var response = (RetrieveEntityResponse)_service.Execute(request);
            return response?.EntityMetadata;
        }
