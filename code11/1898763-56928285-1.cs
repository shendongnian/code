    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"(\([^)]*?\bgroup\b\s+\bby\b[^)]*?\))";
            string input = @"(SELECT  column1, column2
    FROM Table_name1)
    
     INNER JOIN (                                            
     SELECT column1, column2
     FROM   Table_name2     
     WHERE  column1 > 0                                                      
     GROUP BY column1, column2   
     ) AS TN
    
    (SELECT  column1, column2
    FROM Table_name1)
    
     INNER JOIN (                                            
     SELECT column1, column2
     FROM   Table_name2     
     WHERE  column1 > 0                                                      
     GROUP BY column1, column2   
     ) AS TN";
            RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Singleline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
