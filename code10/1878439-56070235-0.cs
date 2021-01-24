            try
            {
                var result = client.CreateNamespacedDeployment(deployment, namespace);
            }
            catch (Microsoft.Rest.HttpOperationException httpOperationException)
            {
                var phase = httpOperationException.Response.ReasonPhrase;
                var content = httpOperationException.Response.Content;
            }
