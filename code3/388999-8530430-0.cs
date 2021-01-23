    using System;
    
    class Program
    {
        static void Main(string[] args)
        {
            var s = "%K2% %K3% %K4%";
            var replaces = new[]
                               {
                                   new[] {"%K3%", "%K2%"},
                                   new[] {"%K2%", "%K4%"},
                                   new[] {"%K4%", "%K2%"},
                               };
    
            bool wasReplaces;
            var curPos = 0;
            do
            {
                wasReplaces = false;
    
                string[] curReplacement = null;
                var minIndex = int.MaxValue;
    
                foreach (var replacement in replaces)
                {
                    var index = s.IndexOf(replacement[0], curPos);
                    if ((index < minIndex) && (index != -1))
                    {
                        minIndex = index;
                        curReplacement = replacement;
                    }
                }
    
                if (curReplacement != null)
                {
                    s = s.Substring(0, minIndex) + curReplacement[1] + s.Substring(minIndex + curReplacement[0].Length);
                    curPos = minIndex + curReplacement[0].Length + 1;
                    wasReplaces = true;
                }
    
            } while (wasReplaces && (curPos < s.Length));
    
            // Should be "%K4% %K2% %K2%
            Console.WriteLine(s);
        }
    }
