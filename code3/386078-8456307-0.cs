    class WineCountriesIndex: AbstractIndexCreationTask<WineDocument, WineCountriesIndex.Result> {
        public class Result {
            public string Country { get; set; }
        }
        public WineCountriesIndex() {
            Map = wines => from wine in wines
                           where wine.Country != null
                           select new { Country = wine.Country };
            Reduce = results => from result in results
                                group result by result.Country into g
                                select new { Country = g.Key };
        }
    }
