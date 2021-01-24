    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Xunit;
    
    namespace SampleTest
    {
        public class SampleTests
        {
            [Fact]
            public void TestPatternSplit()
            {
                
                var input = @"AV Rocket 456:Contact?:Jane or Tarzan:URL?:http?://www.jane.com:Time Delivered 18?:15:Product Description";
    
                var output = PatternSplit(input);
    
                var expected = new[]{"AV Rocket 456", "Contact?:Jane or Tarzan", "URL?:http?://www.jane.com","Time Delivered 18?:15","Product Description"};
    
                Assert.Equal(expected, output);
    
            }
    
            private static IEnumerable<string> PatternSplit(string input)
            {
                const string  pattern = @"([^:?]|(?:[?][:]))*";
                var matchedStrings = Regex.Matches(input, pattern);
                var output = new List<string>();
                foreach (Match match in matchedStrings)
                {
                    if (match.Groups[0].Length > 0) 
                        output.Add(match.Groups[0].Value);
                }
    
                return output;
            }
        }
    }
