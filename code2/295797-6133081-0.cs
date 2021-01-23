    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    namespace RegExExample
    {
        public class Program
        {
            static void Main()
            {
                var urls = new List<Url>
                {
                    new Url
                    {
                        Name = "Match 1",
                        Address = "http://www.mywebsite.com/abc123.aspx"
                    },
                    new Url
                    {
                        Name = "Match 2",
                        Address = "http://www.mywebsite.com/abc45.aspx"
                    },
                    new Url
                    {
                        Name = "Match 3",
                        Address = "http://www.mywebsite.com/abc5678.aspx"
                    },
                    new Url
                    {
                        Name = "No Match 1",
                        Address = "http://www.otherwebsite.com/abc123.aspx"
                        // No match because otherwebsite.com
                    },
                    new Url
                    {
                        Name = "No Match 2",
                        Address = "http://www.mywebsite.com/def123.aspx"
                        // No match because def
                    }
                };
    
                // Will match on http://www.mywebsite.com/abc#.aspx, where # is 1 or more digits
                const string regExCommand = "(http://www.mywebsite.com/abc\\d+\\.aspx)";
    
                var r = new Regex(regExCommand, RegexOptions.IgnoreCase | RegexOptions.Singleline);
    
                urls.ForEach(u =>
                {
                    var m = r.Match(u.Address);
                    if (m.Success)
                    {
                        Console.WriteLine(String.Format("Name: {0}{1}Address: {2}{1}",
                                                        u.Name,
                                                        Environment.NewLine,
                                                        u.Address));
                    }
                });
                
                Console.ReadLine();
            }
        }
    
        internal class Url
        {
            public string Name { get; set; }
            public string Address { get; set; }
        }
    }
