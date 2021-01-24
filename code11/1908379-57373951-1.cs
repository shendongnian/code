    var config = new PactVerifierConfig
            {
                        
                Outputters = new List<IOutput>
                                {
                                    new XUnitOutput(_outputHelper)
                                },
                //Custom header
                CustomHeader = new KeyValuePair<string, string>("testId","test123"),
                // Output verbose verification logs to the test output
                Verbose = true
            };
