    using System;
    using System.Text.RegularExpressions;
    
    class MyClass
    {
        static void Main(string[] args)
        {
            string pattern = @"<a href=\"[^\(]*\('([^']+)'\);\">";
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
            string sInput = "click <a href=\"javascript:validate('http://www.google.com');\">here</a> to open google.com";
    
            MyClass c = new MyClass();
    
            // Assign the replace method to the MatchEvaluator delegate.
            MatchEvaluator myEvaluator = new MatchEvaluator(c.ReplaceCC);
    
            // Write out the original string.
            Console.WriteLine(sInput);
    
            // Replace matched characters using the delegate method.
            sInput = r.Replace(sInput, myEvaluator);
    
            // Write out the modified string.
            Console.WriteLine(sInput);
        }
    
        // Replace each Regex cc match
        public string ReplaceCC(Match m)
        {
            return "click <a href=\"" + m.Group[0] + "\">";
        }
    }
