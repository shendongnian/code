     parsedArray = JArray.Parse(receivedData);
     foreach (JObject ob in parsedArray.Children<JObject>())
                            {
                                  
                                    var name = (string)ob["name"];
                                   
                                    if (name == "My ecobee")
                                    {
                                        device_id = (string)ob["_id"];
                                      
                                        var json = (JArray)ob["actions"];
                                        foreach (JObject ob1 in json.Children<JObject>())
                                        {
                                            var actionname = (string)ob1["action_def"]["id"];
                                            if (actionname == "increase_temp_by")
                                            {
                                                action_id = (string)ob1["_id"];
                                                strname = (string)ob1["params"][0]["id"];
    
                                            }
                                        }
                                }
