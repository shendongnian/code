    using System;
    using System.Collections.Generic;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args) {
                var registries = FetchAllRegistries();
                foreach ( KeyValuePair<string, Dictionary<string,string>> domain in registries ) {
                    Console.WriteLine("Domain: "+domain.Key);
                    foreach ( KeyValuePair<string,string> entry in domain.Value ) {
                        Console.WriteLine("  "+entry.Key+" "+entry.Value);
                    }                
                }
            }
            private static Dictionary<string, Dictionary<string, string>> FetchAllRegistries() {
                return db.Registries
                    .GroupBy(x => x.Domain)
                    .Select(g => g.ToDictionary(
                        d => d.Domain,
                        d => d.ToDictionary(
                            kv => kv.Key,
                            kv => kv.Value
                        )
                    ))
                ;
            }
            private static Dictionary<string, Dictionary<string, string>> FetchRegistry(string domainName) {
                return db.Registries
                    .Where(x => x.Domain == domainName)
                    .ToDictionary(
                        x => x.Key
                      , x => x.Value
                    );
            }
        }
    }
