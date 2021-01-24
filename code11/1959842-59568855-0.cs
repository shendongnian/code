    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Flurl;
    using Flurl.Http;
    
    namespace SO_59567958
    {
        class Program
        {
            static async Task Main(string[] args)
            {
                var ids = new[] { "1023086709", "1659325215", "1912946427", "1740219450", "1750497640", "1538260823", "1275625626", "1144303488", "1205919107", "1730281890", "1568453561" };
                Console.WriteLine($"Retrieving {ids.Length} NPI records...");
                var npiResults = new List<Result>();
                foreach (var id in ids)
                {
                    var retrievedFromApi = await GetNpiEntry(id);
                    npiResults.Add(retrievedFromApi);
                }
    
                Console.WriteLine("Done");
                npiResults.ForEach(x => Console.WriteLine(x.Number));
            }
    
            static async Task<Result> GetNpiEntry(string npiNumber)
            {
                var npiEntry = await "https://npiregistry.cms.hhs.gov"
                    .AppendPathSegment("api/")
                    .SetQueryParams(new { version = "2.1", number = npiNumber })
                    .GetJsonAsync<RootObject>();
    
                return npiEntry.Results[0];
            }
        }
    
        public class RootObject
        {
            public int ResultCount { get; set; }
    
            public IReadOnlyList<Result> Results { get; set; }
        }
    
        public class Result
        {
            public int Number { get; set; }
        }
    }
