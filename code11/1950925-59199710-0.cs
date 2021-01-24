                    var obj = JObject.Parse(partialJson);
                    Opt opt = root.SPFeed.opt;
                    if (obj["opt"]["data"]["DR"] != null) {
                            IList<JToken> DR = JObject.Parse(obj["opt"]["data"]["DR"].ToString());
                            var DRindex = Convert.ToInt32(((JProperty)DR[0]).Name);
                            var O = ((JProperty)DR[0]).Value;
                            JToken Otemp = JToken.Parse(O.ToString());
                            if (Otemp["O"] != null)
                            {
                                var Oindex = Otemp["O"];
                                foreach (JToken item in Oindex)
                                {
                                    int index = Convert.ToInt32(((JProperty)item).Name);
                                    string value = ((JProperty)item).Value.ToString();
                                    Console.WriteLine("Index {0} Value {1}", index, value);
                                    opt.data.DR[DRindex].O[index] = value;
                                }
                            }
                    };
