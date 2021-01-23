    using System;
    using System.Text.RegularExpressions;
     
    public class Test {
     
            public static void Main() {
                    // input string     
                    string txt = "/home/{value1}/something/{anotherValue}";
                    // template replacements
                    string[] str_array = { "one", "two" };
                    // regex to match a template
                    Regex regex = new Regex("{[^}]*}");
                    // replace the first template occurrence for each element in array
                    foreach (string s in str_array) {
                            txt = regex.Replace(txt, s, 1);
                    }
                    
                    Console.Write(txt);
     
            }
    }
