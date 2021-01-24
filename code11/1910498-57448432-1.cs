    using System;
    using System.Linq;
    namespace Foo
    {
        class Program
        {
            static void Main(string[] args)
            {
                 var sentence = "For several years I’ve had a little “utility” function that I’ve used in several projects that I use to convert property names into strings. One use case is for instance when mapping code to some data source or third party API that where the names are used as keys. The method uses “static reflection”, or rather it parses the expression tree from a lambda expression, to figure out the name of a property that the lambda expression returns the value of.Look, good against remotes is one thing, good against the living, that’s something else.";
                var keyword = "instance";
                var words = sentence.Split(' ').ToArray(); // split into words
                int index = Array.FindIndex(words, w => w.Equals(keyword)); // find the index within
                // take 11 words from 5 before the index of your keyword
                var r = Enumerable
                    .Range(index - 5, 11)
                    .Select(i => words[i]);
                var result = string.Join(' ', r);
                Console.WriteLine("Output:- {0} ", result);
                Console.ReadKey();
            }
        }
    }
