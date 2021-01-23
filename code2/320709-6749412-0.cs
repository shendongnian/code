    using System;
    using System.Text.RegularExpressions;
     
    public class Test
    {
            public static void Main()
            {
                    String sample = "<a href=\"http://test.com\" rel=\"nofollow\">LoremIpsum.Net</a> is a small and simple static site that <a href=\"http://test123.com\" rel=\"nofollow\">provides</a> you with a decent sized passage without having to use a generator. The site also provides an all caps version of the text, as well as translations, and an <a href=\"http://test445.com\" rel=\"nofollow\">explanation</a> of what this famous.";
     
                    String re = @"<a [^>]+>(.*?)<\/a>";
                    Console.WriteLine(Regex.Replace(sample, re, "$1"));
            }
    }
