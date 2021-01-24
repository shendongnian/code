        void SomeFunction()
        {
            Dictionary<string, decimal> json_data = new Dictionary<string, decimal>();
            dynamic json_obj = JsonConvert.DeserializeObject(json);
            Linearize(ref json_data, json_obj);
        }
        void Linearize(ref Dictionary<string, decimal> input_dict, JToken json_data, string key = "")
        {
            int i;
            if (json_data != null)
            {
                if (json_data.HasValues)
                {
                    i = 0;
                    foreach (dynamic entry in json_data)
                    {
                        //Add a Name field if it exists
                        Type typeOfDynamic = entry.GetType();
                        if (typeOfDynamic.GetProperties().Where(p => p.Name.Equals("Name")).Any())
                            key += entry.Name + ".";
                        //If JToken is an Array
                        if (((JToken)entry).HasValues)
                        {
                            Linearize(ref input_dict, entry, key + "[" + i++ + "]" + ".");
                        }
                        //If JToken is a data type
                        else if (entry.Type == JTokenType.String || entry.Type == JTokenType.Float || entry.Type == JTokenType.Integer)
                        {
                            decimal output;
                            if (decimal.TryParse(entry.ToString(), out output))
                                input_dict.Add(key + "[" + i++ + "]", output);
                        }
                    }
                }
            }           
        }
