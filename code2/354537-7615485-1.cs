    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Lucene.Net.Search;
    using Lucene.Net.Documents;
    using Lucene.Net.Index;
    using Lucene.Net.Analysis.Standard;
    using System.IO;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            public class RoleFilterCache
            {
                static public Dictionary<string, Filter> Cache = new Dictionary<string,Filter>();
    
                static public Filter Get(string role)
                {
                    Filter cached = null;
                    if (!Cache.TryGetValue(role, out cached))
                    {
                        return null;
                    }
                    return cached;
                }
    
                static public void Put(string role, Filter filter)
                {
                    if (role != null)
                    {
                        Cache[role] = filter;
                    }
                }
            }
    
            public class User
            {
                public string Username;
                public List<string> Roles;
            }
    
            public static Filter GetFilterForUser(User u)
            {
                BooleanFilter userFilter = new BooleanFilter();
                foreach (string rolename in u.Roles)
                {   
                    // call GetFilterForRole and add to the BooleanFilter
                    userFilter.Add(
                        new BooleanFilterClause(GetFilterForRole(rolename), BooleanClause.Occur.SHOULD)
                    );
                }
                return userFilter;
            }
    
            public static Filter GetFilterForRole(string role)
            {
                Filter roleFilter = RoleFilterCache.Get(role);
                if (roleFilter == null)
                {
                    roleFilter =
                        // the caching wrapper filter makes it cache the BitSet per segmentreader
                        new CachingWrapperFilter(
                            // builds the filter from the index and not from iterating
                            // stored doc content which is much faster
                            new QueryWrapperFilter(
                                new TermQuery(
                                    new Term("security", role)
                                )
                            )
                    );
                    // put in cache
                    RoleFilterCache.Put(role, roleFilter);
                }
                return roleFilter;
            }
    
    
            static void Main(string[] args)
            {
                IndexWriter iw = new IndexWriter(new FileInfo("C:\\example\\"), new StandardAnalyzer(), true);
                Document d = new Document();
    
                Field aField = new Field("content", "", Field.Store.YES, Field.Index.ANALYZED);
                Field securityField = new Field("security", "", Field.Store.NO, Field.Index.ANALYZED);
    
                d.Add(aField);
                d.Add(securityField);
    
                aField.SetValue("Only one can see.");
                securityField.SetValue("1");
                iw.AddDocument(d);
                aField.SetValue("One and two can see.");
                securityField.SetValue("1 2");
                iw.AddDocument(d);
                aField.SetValue("One and two can see.");
                securityField.SetValue("1 2");
                iw.AddDocument(d);
                aField.SetValue("Only two can see.");
                securityField.SetValue("2");
                iw.AddDocument(d);
    
                iw.Close();
    
                User userone = new User()
                {
                    Username = "User one",
                    Roles = new List<string>()
                };
                userone.Roles.Add("1");
                User usertwo = new User()
                {
                    Username = "User two",
                    Roles = new List<string>()
                };
                usertwo.Roles.Add("2");
                User userthree = new User()
                {
                    Username = "User three",
                    Roles = new List<string>()
                };
                userthree.Roles.Add("1");
                userthree.Roles.Add("2");
    
                PhraseQuery phraseQuery = new PhraseQuery();
                phraseQuery.Add(new Term("content", "can"));
                phraseQuery.Add(new Term("content", "see"));
    
                IndexSearcher searcher = new IndexSearcher("C:\\example\\", true);
    
                Filter securityFilter = GetFilterForUser(userone);
                TopDocs results = searcher.Search(phraseQuery, securityFilter,25);
                Console.WriteLine("User One Results:");
                foreach (var aResult in results.ScoreDocs)
                {
                    Console.WriteLine(
                        searcher.Doc(aResult.doc).
                        Get("content")
                    );
                }
                Console.WriteLine("\n\n");
    
                securityFilter = GetFilterForUser(usertwo);
                results = searcher.Search(phraseQuery, securityFilter, 25);
                Console.WriteLine("User two Results:");
                foreach (var aResult in results.ScoreDocs)
                {
                    Console.WriteLine(
                        searcher.Doc(aResult.doc).
                        Get("content")
                    );
                }
                Console.WriteLine("\n\n");
    
                securityFilter = GetFilterForUser(userthree);
                results = searcher.Search(phraseQuery, securityFilter, 25);
                Console.WriteLine("User three Results (should see everything):");
                foreach (var aResult in results.ScoreDocs)
                {
                    Console.WriteLine(
                        searcher.Doc(aResult.doc).
                        Get("content")
                    );
                }
                Console.WriteLine("\n\n");
                Console.ReadKey();
            }
        }
    }
