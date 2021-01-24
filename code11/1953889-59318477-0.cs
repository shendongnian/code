    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    
    public class Program
    {
        public static void Main()
        {
            string str = @"[0]: {{
    							   'projectId': 111,
    							   'userId': 11,
    							   'name': 'Bill, Gates',
    							   'value': '11'
    							 }}
    							[1]: {{
    							   'projectId': 222,
    							   'userId': 22,
    							   'name': 'Cill, Gates',
    							   'value': '22'
    							 }}";
    
            showMatch(str, @"('(.*)':(.*)[',])");
        }
    
        static private void showMatch(string text, string expr)
        {
            //Declare what is required! Phew
            List<MyClass> output = new List<MyClass>();
            int projectId=0;
            int userId=0;
            string name=string.Empty;
            string value=string.Empty;
    
            var regEx = new Regex(@"[^0-9a-zA-Z]+");
    
            //Start the matching process
            MatchCollection mc = Regex.Matches(text, expr);
            bool check;
            foreach (Match m in mc)
            {
                check = false;
                string[] parsed = m.ToString().Split(':');
                var stripped = regEx.Replace(parsed[1], "");
                if (parsed[0] == "'projectId'")
                {
                    projectId = Convert.ToInt32(stripped);
                }
                if (parsed[0] == "'userId'")
                {
                    userId = Convert.ToInt32(stripped);
                }
                if (parsed[0] == "'name'")
                {
                    name = stripped;
                }
                if (parsed[0] == "'value'")
                {
                    value = stripped;
                    check = true;
                }
    
                //Add to list
                if(check==true)
                {
                    output.Add(new MyClass { projectId = projectId, userId = userId, name = name, value = value });
                }
            }
    
            output.Dump();
        }
    }
    
    public class MyClass
    {
        public int projectId { get; set; }
        public int userId { get; set; }
        public string name { get; set; }
        public string value { get; set; }
    }
