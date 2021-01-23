     public static dynamic GetWaveAnimation()
    {
        try
        {
            return (from element in configurations.Elements("Animation")
                    where element.Attribute("NAME").Value == "Wave"
                    select new
                        {
                            time = element.Attribute("TIMING").Value,
                            enable = element.Attribute("ENABLED").Value
                        }).FirstOrDefault();
        }
        catch { return null; }
    }
