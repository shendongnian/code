    public struct Wave{
         public X time;
         public Y enable;
    }
    public static Wave GetWaveAnimation()
        {
            try
            {
                return (from element in configurations.Elements("Animation")
                        where element.Attribute("NAME").Value == "Wave"
                        select new Wave
                            {
                                time = element.Attribute("TIMING").Value,
                                enable = element.Attribute("ENABLED").Value
                            }).FirstOrDefault();
            }
            catch { return null; }
        }
