            static void Main()
            {
                List<string> cultureList = new List<string>();
                CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures & ~CultureTypes.NeutralCultures);
                foreach (CultureInfo culture in cultures)
                {   
                    try
                    {
                        RegionInfo region = new RegionInfo(culture.Name);
                        if (!(cultureList.Contains(region.EnglishName)))
                            cultureList.Add(region.EnglishName);
                        Console.WriteLine(region.EnglishName); 
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(String.Format("For{0} a specific culture name is required.", culture.Name));
                    }                  
                }
            }
