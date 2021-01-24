    foreach (var line in lines)
            {
                var json = JObject.Parse(line);
                var eventType = json["event"].Value<string>();
                switch (eventType)
                {
                    case "Friends":
                        var status = json["Status"].Value<string>();
                        var frName = json["Name"].Value<string>();
                        Console.WriteLine("The friend " + frName + " is currently " + status + ".");
                        Console.WriteLine(json);
                        break;
                    case "Commander":
                        var fid = json["FID"].Value<string>();
                        var CMDR = json["Name"].Value<string>();
                        Console.WriteLine("User " + CMDR + " with ID " + ".");
                        Console.WriteLine(json);
                        break;
                    case "Materials":
                        var raw = JArray.Parse(json["Raw"].ToString());
                        foreach(JToken token in raw)
                        {
                            Console.WriteLine("Name " + token["Name"] + " Counter " + token["Count"]);
                        }
                        
                        break;
                    default:
                        Console.WriteLine("N/A");
                        break;
                }
            }
