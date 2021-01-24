            List<T> result = new List<T>();
            string continuationToken = null;
            IDocumentQuery<T> docQuery = queryable.AsDocumentQuery();
            // ugly hack to get the feed options using reflection
            FeedOptions feedOptions = docQuery.GetNonPublicProperty<FeedOptions>("feedOptions");
            while (docQuery.HasMoreResults && (pageSize <= 0 || result.Count < pageSize))
            {
                if (feedOptions != null && pageSize > 0)
                {
                    feedOptions.MaxItemCount = pageSize - result.Count;
                }
                FeedResponse<T> response = await docQuery.ExecuteNextAsync<T>();
                result.AddRange(response.ToList());
                continuationToken = response.ResponseContinuation;
            }
            return (result, continuationToken);
