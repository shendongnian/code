    GoogleCredential credential;
                        using (var stream = new FileStream(serviceAccountCredentialFilePath, FileMode.Open, FileAccess.Read))
                        {
                            credential = GoogleCredential.FromStream(stream)
                                 .CreateScoped(scopes);
                        }
    
                        // Create the  Analytics service.
                        return new CalendarService(new BaseClientService.Initializer()
                        {
                            HttpClientInitializer = credential,
                            ApplicationName = "Calendar Service account Authentication Sample",
                        });
