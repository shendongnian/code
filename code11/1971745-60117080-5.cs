    //Same as your code
            var fullPath = @"C:\testLog.log";
            string[] lines = File.ReadAllLines(fullPath);
            //This dictionary stores each of your different log types in a way where you can use the "event" string in each json to get the c# object type
            Dictionary<string, Type> types = new Dictionary<string, Type>()
            {
                { "Friends", typeof(Friends)},
                {"Commander", typeof(Commander) },
                {"Materials", typeof(Materials) }
            };
            foreach (var line in lines)
            {
                //Same as your code
                var json = JObject.Parse(line);
                Type eventType = types[json["event"].Value<string>()];
                //This line will use the event type provided by the json to deserialise your object
                var x = JsonConvert.DeserializeObject(line, eventType);
                switch (x)
                {
                    case Friends friendObject:
                        //Do stuff with the friend object here
                        Console.WriteLine("Friend log found");
                        Console.WriteLine(friendObject.Timestamp);
                        Console.WriteLine(friendObject.Name);
                        Console.WriteLine(friendObject.Status);
                        Console.WriteLine();
                        break;
                    case Commander commanderObject:
                        //Do stuff with the commander object here
                        Console.WriteLine("Commander log found");
                        Console.WriteLine(commanderObject.Timestamp);
                        Console.WriteLine(commanderObject.FID);
                        Console.WriteLine(commanderObject.Name);
                        Console.WriteLine();
                        break;
                    case Materials materialsObject:
                        //do stuff with the material object here
                        Console.WriteLine("Materials log found");
                        Console.WriteLine(materialsObject.Timestamp);
                        materialsObject.Raw.ForEach(material=>Console.WriteLine(material.Name + ". Count: " + material.Count));
                        break;
                }
            }
