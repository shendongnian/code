    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace SO6299404
    {
        class Author
        {
            public string FirstName;
            public string LastName;
        }
        class Magazine
        {
            public string Title;
            public string ISBN;
            public List<Article> TOC;
        
            // Code Until the end of the class is for testing only
            public void Dump()
            {
                Dump(0);
            }
            public void Dump(int indent)
            {
                Console.WriteLine("".PadLeft(indent) + Title);
                if (TOC != null)
                {
                    foreach (Article article in TOC)
                    {
                        article.Dump(indent + 2);
                    }
                }
            }
        }
        class Article
        {
            public string Title;
            public string Header;
            public string Body;
            public int PageNumber;
            public Magazine Source;
            public Author Author;
            // Code Until the end of the class is for testing only
            public void Dump()
            {
                Dump(0);
            }
            public void Dump(int indent)
            {
                string author = Author == null ? "" : Author.FirstName;
                Console.WriteLine("".PadLeft(indent) + Title + ", " + author);
            }
        }
        // A foreach extension. Not strictly nescessary, but having this extension
        // makes it a bit easier to write foreach loops
        public static class EnumerableExtension
        {
            public static void Foreach<T>(this IEnumerable<T> enumerable, Action<T> action)
            {
                if (enumerable == null) throw new ArgumentNullException("enumerable");
                if (action == null) throw new ArgumentNullException("action");
                foreach (T value in enumerable)
                    action(value);
            }
        }
        class Program
        {
            static void Main()
            {
                List<Magazine> magazines = SetupTestCase();
                // Let's print out our test case
                Console.WriteLine("==[Setup]===========================");
                magazines.Foreach(x => x.Dump());
                // So now we need to extraxct all Authors and list articles belonging to them
                // First we get Authorl; Article pair and then we group by Authors
                var temp = magazines.SelectMany(m => m.TOC, (a, b) => new {b.Author, Article = b}).GroupBy(x => x.Author);
            
                // Ok, we are done. Let's print out the results
                Console.WriteLine("==[REsult]===========================");
                temp.Foreach(x =>
                {
                    Console.WriteLine(x.Key.FirstName);
                    x.Foreach( y => y.Article.Dump(2));
                });
            }
            // The code from here until the end of the class is for generating a test case only
            private static List<Magazine> SetupTestCase()
            {
                // Let's set up a test case similar to the example in the question
                // We generate 5 Authors
                Author[] authors = Seed(1, 5).Select(x => GenerateTestAuthor(x.ToString())).ToArray();
                        
                // And 9 Articles
                Article[] articles = Seed(1,9).Select(x => GenerateTestArticle(x.ToString())).ToArray();
            
                // This defines how articles are connected to authors
                int[] articleToAuthor = new[] {0,1,2,3,4,3,2,1,0};
            
                // Let's connect articles and authors as per definition abbove
                Seed(9).Foreach(x=> {articles[x].Author = authors[articleToAuthor[x]];});
            
                // Now 3 Magazines
                Magazine[] magazines = Seed(1,3).Select(x => GenerateTestMagazine(x.ToString())).ToArray();
                // This deines which articles go in which magazine
                int[] articleToMagazine = new[] {0,0,0,1,1,1,2,2,2};
            
                // Let's add artices to the Magazines
                Seed(9).Foreach(x=> magazines[articleToMagazine[x]].TOC.Add(articles[x]));
                // And now let us link back from articles to Magazines
                magazines.Foreach(x => x.TOC.Foreach(z => z.Source = x));
                return magazines.ToList();
            }
        
            static IEnumerable<int> Seed(int start, int count)
            {
                return Enumerable.Range(start, count);
            }
            static IEnumerable<int> Seed(int n)
            {
                return Seed(0, n);
            }
            static Article GenerateTestArticle(string id)
            {
                return new Article
                {
                    Title = "Title" + id,
                    Header = "Title" + id,
                    Body = "Title" + id,
                    PageNumber = 1,
                };
            }
        
            static Author GenerateTestAuthor(string id)
            {
                return new Author
                {
                    FirstName = "Author" + id,
                    LastName = "Author" + id,
                };
            }
            static Magazine GenerateTestMagazine(string id)
            {
                return new Magazine
                {
                    Title = "Magazine" + id,
                    ISBN = "Magazine" + id,
                    TOC = new List<Article>()
                };
            }
        }
    }
