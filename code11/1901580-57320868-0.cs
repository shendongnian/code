    var rFile = GoogleCredential.FromFile(jsonkeyfilepath);
            var scopeC = rFile.CreateScoped(DialogflowService.Scope.CloudPlatform);
            var response = new DialogflowService(new BaseClientService.Initializer
            {
                HttpClientInitializer = scopeC,
                ApplicationName = "project-name-here"
            }).Projects.Agent.Sessions.DetectIntent(
                        new GoogleCloudDialogflowV2beta1DetectIntentRequest
                        {
                            QueryInput = new GoogleCloudDialogflowV2beta1QueryInput
                            {
                                Text = new GoogleCloudDialogflowV2beta1TextInput
                                {
                                    Text = "your text here",
                                    LanguageCode = "en-US"
                                }
                            }
                        },
                        $"projects/projectid/agent/sessions/34141414")
                        .Execute();
            return (JsonConvert.SerializeObject(response.QueryResult));
 
