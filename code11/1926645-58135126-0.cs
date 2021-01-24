            JObject jObj = (JObject)JsonConvert.DeserializeObject(jsonString.ToString());
            foreach (var level1 in jObj)
            {
                var jObjKey = level1.Key;
                //get the final loop here before foreach
                JObject finalLoop = (JObject)JsonConvert.DeserializeObject(level1.Value.ToString());
                foreach (var level2 in finalLoop)
                {
                    //check whether the level2 have keyvaluepair
                    if (level2.Value.Count()>1)
                    {
                        //push the keyvaluepair to dictionary or dynamic object
                        Dictionary<string, object> dictObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(level2.Value.ToString());
                        if (dictObj.Keys.Contains("labels"))
                        { 
                            Console.WriteLine(dictObj["labels"]);
                        }
                    }
                }
            }
