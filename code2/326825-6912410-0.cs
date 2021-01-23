    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
     
    public class Test
    {
            public static void Main()
            {
                    List<String> samples = new List<String>(new[]{
                            "0A055","0A050","0A500","0A0505","0055","0505","0050"
                    });
     
                    String re = @"^0*([A-Z]*)0*([1-9]\d*)$";
     
                    // iterate over all results
                    samples.ForEach(n => {
                            Console.WriteLine("\"{0}\" -> \"{1}\"",
                                    n,
                                    Regex.Replace(n, re, "$1$2")
                            );
                    });
            }
    }
