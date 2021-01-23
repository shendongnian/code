        IEnumerable<UnitConversion> IUnitConversionSource.UnitConversions(DirectAgentsEntities model)
        {
            string unit = model.Units.First(c => c.Name == "USD");
            yield return new UnitConversion
            {
                Coefficient = 1,
                FromUnit = unit,
                ToUnit = unit,
                DateSpan = new DateSpan
                {
                    FromDate = DateTime.Now,
                    ToDate = DateTime.Now.Add(TimeSpan.FromHours(1))
                }
            };
        }
