        static void Main(string[] args)
        {
            try
            {
                //Violation of Primary Key
                DataClasses1DataContext ctx = new DataClasses1DataContext();
                ctx.t_countries.InsertOnSubmit(new t_country
                    {
                        CountryName = "USA",
                        CountryCode = 1,
                        CharacterSet = "blah",
                        CurrencySet = "blah",
                        HasRegion = true,
                        HasState = true,
                        HasSubRegion = true,
                        Language = "Anglish",
                        Name = "Cool",
                        SMPITargetSystem = "cool",
                        SourceSystem = "source",
                        TimingSourceSystem = "timing"
                    });
                ctx.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                //How to do an update
                var country = (from i in ctx.t_countries
                               where i.CountryCode == 1
                               select i).FirstOrDefault();
                if (country != null)
                {
                    country.CountryName = "Venezuela";
                }
                ctx.SubmitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
