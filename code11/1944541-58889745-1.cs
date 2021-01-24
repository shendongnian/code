    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Xunit;
    
    namespace XUnitTestProject1
    {
        public class UnitTest1
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
                const string  pattern = @"(?<!\?):";
                return Regex.Split(input, pattern);
            }
        }
    }
