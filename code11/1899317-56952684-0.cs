    var asyncHandle = client.ExecuteAsync<T>(request, restResponse =>
            {
                // check respone 
                if (restResponse.ResponseStatus == ResponseStatus.Completed)
                {
                    result = restResponse.Data;
                }
                //else
                //    throw new Exception("Call stopped with Status: " + response.StatusCode +
                //                        " Description: " + response.StatusDescription);
            });
