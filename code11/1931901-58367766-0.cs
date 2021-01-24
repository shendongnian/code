    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"(?<=<table>)\s*<tr>\s*<td>([a-z0-9 ]*)<\/td>\s*<\/tr>";
            string input = @"<table>
        <tr>
            <td>Text A</td>
        </tr>
        <tr>
            <td>
                <table>  <!-- Notice this is an inner scope table -->
                    <tr>
                        <td>Text B</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    
    <table>
        <tr>
            <td>
                <table> <!-- Notice this is an inner scope table -->
                    <tr>
                        <td>Text C</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    
    <table>
        <tr>
            <td>Text D</td>
        </tr>
    </table>";
            RegexOptions options = RegexOptions.Singleline | RegexOptions.IgnoreCase;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
