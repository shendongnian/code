    public string test(SimpleTableExample ste)
            {
                
                ExamplesEntities1 ex1 = new ExamplesEntities1();
                var results = ex1.USP_UPSERT_SimpleTableExample(ste.NaturalKey1, ste.NaturalKey2, ste.NaturalKey3, ste.DataField).ToList<SimpleTableExample>();
                string returnvalue = results.First().SurrogateKey.ToString();
                return returnvalue;
            }
