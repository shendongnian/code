    public class RootObject
            {
                public string fieldName { get; set; }
                public object targetValue { get; set; }
                public object sourceValue { get; set; }
            }
    
            private static List<RootObject> CompareObjects(JObject source, JObject target, List<RootObject> rootObjects)
            {
                foreach (KeyValuePair<string, JToken> sourcePair in source)
                {
                    if (sourcePair.Value.Type == JTokenType.Object)
                    {
                        if (target.GetValue(sourcePair.Key) == null)
                        {
                            RootObject rootObject = new RootObject();
                            rootObject.fieldName = sourcePair.Key;
                            rootObject.sourceValue = sourcePair.Value;
                            rootObject.targetValue = "";
                            rootObjects.Add(rootObject);
                        }
                        else if (target.GetValue(sourcePair.Key).Type != JTokenType.Object)
                        {
                            RootObject rootObject = new RootObject();
                            rootObject.fieldName = sourcePair.Key;
                            rootObject.sourceValue = sourcePair.Value;
                            rootObject.targetValue = "";
                            rootObjects.Add(rootObject);
                        }
                        else
                        {
                            rootObjects = CompareObjects(sourcePair.Value.ToObject<JObject>(),
                                target.GetValue(sourcePair.Key).ToObject<JObject>(), rootObjects);
                        }
                    }
                    else if (sourcePair.Value.Type == JTokenType.Array)
                    {
                        if (target.GetValue(sourcePair.Key) == null)
                        {
                            RootObject rootObject = new RootObject();
                            rootObject.fieldName = sourcePair.Key;
                            rootObject.sourceValue = sourcePair.Value;
                            rootObject.targetValue = "";
                            rootObjects.Add(rootObject);
                        }
                        else
                        {
                            rootObjects=CompareArrays(sourcePair.Value.ToObject<JArray>(),
                                target.GetValue(sourcePair.Key).ToObject<JArray>(),rootObjects, sourcePair.Key);
                        }
                    }
                    else
                    {
                        JToken expected = sourcePair.Value;
                        var actual = target.SelectToken(sourcePair.Key);
                        if (actual == null)
                        {
                            RootObject rootObject = new RootObject();
                            rootObject.fieldName = sourcePair.Key;
                            rootObject.sourceValue = sourcePair.Value;
                            rootObject.targetValue = "";
                            rootObjects.Add(rootObject);
                        }
                        else
                        {
                            if (!JToken.DeepEquals(expected, actual))
                            {
                                RootObject rootObject = new RootObject();
                                rootObject.fieldName = sourcePair.Key;
                                rootObject.sourceValue = sourcePair.Value;
                                rootObject.targetValue = target.Property(sourcePair.Key).Value;
                                rootObjects.Add(rootObject);
                            }
                        }
                    }
                }
                return rootObjects;
            }
    
            private static List<RootObject> CompareArrays(JArray source, JArray target, List<RootObject> rootObjects , string arrayName = "")
            {
                for (var index = 0; index < source.Count; index++)
                {
    
                    var expected = source[index];
                    if (expected.Type == JTokenType.Object)
                    {
                        var actual = (index >= target.Count) ? new JObject() : target[index];
                        rootObjects = CompareObjects(expected.ToObject<JObject>(),
                            actual.ToObject<JObject>(), rootObjects);
                    }
                    else
                    {
    
                        var actual = (index >= target.Count) ? "" : target[index];
                        if (!JToken.DeepEquals(expected, actual))
                        {
                            if (String.IsNullOrEmpty(arrayName))
                            {
                                RootObject rootObject = new RootObject();
                                rootObject.fieldName = "[" + index + "]";
                                rootObject.sourceValue = expected;
                                rootObject.targetValue = actual;
    
                                rootObjects.Add(rootObject);
                            }
                            else
                            {
    
                                RootObject rootObject = new RootObject();
                                rootObject.fieldName = arrayName + "[" + index + "]";
                                rootObject.sourceValue = expected;
                                rootObject.targetValue = actual;
    
                                rootObjects.Add(rootObject);
                            }
                        }
                    }
                }
                return rootObjects;
            }
