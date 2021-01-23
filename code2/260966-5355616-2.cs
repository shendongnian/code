      public static Tuple<X,Y> GetWaveAnimation()
            {
                try
                {
                    return (from element in configurations.Elements("Animation")
                            where element.Attribute("NAME").Value == "Wave"
                            select Tuple.Create(
                                       element.Attribute("TIMING").Value,
                                       element.Attribute("ENABLED").Value
                                    )
                                }).FirstOrDefault();
                }
                catch { return null; }
            }
