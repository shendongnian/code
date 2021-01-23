    var startRequest = new StartInstancesRequest
                        {
                            InstanceIds = new List<string>() { instanceId }
                        };
                    bool isError = true;
                    StartInstancesResponse startInstancesResponse = null;
                    while (isError)
                    {
                        try
                        {
                            startInstancesResponse=amazonEc2client.StartInstances(startRequest);
                            isError = false;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
                            isError = true;
                        }
                    }
