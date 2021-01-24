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
                        //you can use friendObject.Name etc to access the properties
                        break;
                    case Commander commanderObject:
                        //Do stuff with the commander object here
                        break;
                    case Materials materialsObject:
                        //do stuff with the material object here
                        //you can use materialsObject.Raw to access the array of material objects
                        break;
                }
            }
