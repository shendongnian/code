    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication2
    {
        internal class Site
        {
            public string Title { get; set; }
            public string OtherStuff { get; set; }
            // don't know your site sturcture but this might help
        }
        class Program
        {
            static void Main(string[] args)
            {
                var siteMap =
                    new List<Site>
                      {
                          new Site {OtherStuff = "bla1", Title = "Title 1"},
                          new Site {OtherStuff = "bla2", Title = "Title 2"},
                          new Site {OtherStuff = "bla3", Title = "Title 3"},
                          new Site {OtherStuff = "bla4", Title = "Title 4"},
                          new Site {OtherStuff = "bla5", Title = "Title 5"}
                      };
                var smallSites =
                    new List<Site>
                      {
                          new Site {OtherStuff = "bla1", Title = "Title 1"},
                          new Site {OtherStuff = "bla2", Title = "Another title 2"},
                          new Site {OtherStuff = "bla3", Title = "Another title 3"},
                          new Site {OtherStuff = "bla4", Title = "Title 4"},
                          new Site {OtherStuff = "bla5", Title = "Another title 5"}
                      };
                // group all the matching titles to be checkboxed
                var query = (siteMap.Select(sm => 
                    new {
                          sm.Title,
                          SmallSites = smallSites.Where(ss => ss.Title == sm.Title)
                      }));
                // get any items that don't match
                IEnumerable<Site> query2 =
                    smallSites.Where(ss => !(siteMap.Select(sm => sm.Title))
                                               .Contains(ss.Title));
                string myString1 = "";
                // this is our checkbox items, do those 1st
                foreach (var item in query)
                {
                    if (item.SmallSites.Any())
                    {
                        foreach (var smallSite in item.SmallSites)
                        {
                            myString1 += string.Format("<input type='checkbox'  checked='yes' value='{0}'", smallSite.Title) + Environment.NewLine;
                        }
                    }
                }
                // now throw down our non-checked items
                foreach (var smallSite in query2)
                {
                    myString1 += string.Format("<input type='checkbox' value='{0}'", smallSite.Title) + Environment.NewLine;
                }
                Console.Write(myString1);
                Console.Read();
            }
        }
    }
