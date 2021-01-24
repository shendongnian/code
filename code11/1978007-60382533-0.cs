    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Net;
    namespace ConsoleApplication157
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string[] inputs = {
                                      "a/b.book",
                                      "a/b/c.book",
                                      "a/b/c/d/e.page",
                                      "a/b/c/d/f.page",
                                      "a/b/g.book",
                                      "a/b/g/h/i.page",
                                      "a/b/g/h/j.page",
                                      "k/l.book",
                                      "k/l/m/n.page",
                                      "o/p.book"
                                  };
                List<List<string>> splitArrays = inputs.Select(x => x.Split(new char[] { '/', '.' }).ToList()).ToList();
                XElement root = new XElement("root");
                GetTree(root, splitArrays);
            }
            static void GetTree(XElement parent, List<List<string>> splitArrays)
            {
                var groups = splitArrays.OrderBy(x => x[0]).GroupBy(x => new { path = x.First(), type = x.Last() }).ToArray();
                foreach (var group in groups)
                {
                    List<List<string>> children = null;
                    XElement element = new XElement(group.Key.type, new XAttribute("navtitle", group.Key.path));
                    parent.Add(element);
                    Boolean first = true;
                    foreach (var child in group.OrderByDescending(x => x.Count))
                    {
                        if (child.Count() == 2) //since we sorts by count, 1 indicates we are at the leaf
                        {
                            if (first)
                            {
                                if (children != null)
                                {
                                    GetTree(element, children);
                                    children = null;
                                }
                                first = false;
                            }
                        }
                        else
                        {
                            //remove first index of each splitArray
                            if (children == null) children = new List<List<string>>();
                            List<string> newChild = child.Skip(1).ToList();
                            children.Add(newChild);
                        }
                    }
                    //when there are no elements with count = 1 then call Getree here
                    if (children != null)
                    {
                        GetTree(element, children);
                    }
                }
            }
        }
    }
