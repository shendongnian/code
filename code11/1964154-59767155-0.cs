            if (responsePost.IsSuccessStatusCode)
            {
                // Get the URI of the created resource.
                Uri returnUrl = responsePost.Headers.Location;
                if (returnUrl != null)
                {
                    Console.WriteLine("Employee data successfully added.");
                }
                //Console.WriteLine(returnUrl);
            }
            else
            {
                // application / business logic validation error to show here?
                HttpError error = responsePost.Content.ReadAsAsync<HttpError>().Result;
                Console.WriteLine("Internal server Error: "+error.ExceptionMessage);
            }
