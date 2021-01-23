    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
     
    public class Test
    {
            public static void Main()
            {
                    String regex = @"(.{2}).+@.+(.{2}(?:\..{2,3}){1,2})";
                    String replace = "$1*@*$2";
                    List<String> tests = new List<String>(new String[]{
                            "joe@example.com",
                            "jim@bob.com",
                            "susie.snowflake@heretoday.co.uk",
                            "j@b.us",
                            "bc@nh.us"
                    });
                    tests.ForEach(email =>
                    {
                            Console.WriteLine(Regex.Replace(email, regex, replace));
                    });
            }
    }
