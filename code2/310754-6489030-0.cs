    using System;
    using System.Text.RegularExpressions;
    
    namespace IntPairArrayParserDemo
    {
        class Program
        {
            static void Main(string[] args)
            {
                var input = "2:{{2,10},{6,4}}";
                ParseAndPrintArray(input);
    
                var anotherInput = "2  : { { 2 , 10 } , { 6 , 4 } }";
                ParseAndPrintArray(anotherInput);
            }
    
            private static void ParseAndPrintArray(string input)
            {
                Console.WriteLine("Parsing array {0}...", input);
    
                var array = IntPairArrayParser.Parse(input);
    
                var pairCount = array.GetLength(0);
                for (var i = 0; i < pairCount; i++)
                {
                    Console.WriteLine("Pair found: {0},{1}", array[i, 0], array[i, 1]);
                }
                Console.WriteLine();
            }
        }
    
        internal static class IntPairArrayParser
        {
            public static int[,] Parse(string input)
            {
                if (string.IsNullOrWhiteSpace(input)) throw new ArgumentOutOfRangeException("input");
    
                // parse array length from string
                var length = ParseLength(input);
    
                // create the array that will hold all the parsed elements
                var result = new int[length, 2];
    
                // parse array elements from input
                ParseAndStoreElements(input, result);
    
                return result;
            }
    
            private static void ParseAndStoreElements(string input, int[,] array)
            {
                // get the length of the first dimension of the array
                var expectedElementCount = array.GetLength(0);
    
                // parse array elements
                var elementMatches = Regex.Matches(input, @"{\s*(\d+)\s*,\s*(\d+)\s*}");
    
                // validate that the number of elements present in input is corrent
                if (expectedElementCount != elementMatches.Count)
                {
                    var errorMessage = string.Format("Array should have {0} elements. It actually has {1} elements.", expectedElementCount, elementMatches.Count);
                    throw new ArgumentException(errorMessage, "input");
                }
    
                // parse array elements from input into array
                for (var elementIndex = 0; elementIndex < expectedElementCount; elementIndex++)
                {
                    ParseAndStoreElement(elementMatches[elementIndex], elementIndex, array);
                }
            }
    
            private static void ParseAndStoreElement(Match match, int index, int[,] array)
            {
                // parse first and second element values from the match found
                var first = int.Parse(match.Groups[1].Value);
                var second = int.Parse(match.Groups[2].Value);
    
                array[index, 0] = first;
                array[index, 1] = second;
            }
    
            private static int ParseLength(string input)
            {
                // get the length from input and parse it as int
                var lengthMatch = Regex.Match(input, @"(\d+)\s*:");
                return int.Parse(lengthMatch.Groups[1].Value);
            }
        }
    }
