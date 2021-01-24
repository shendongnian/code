C#
//avoid null reference exception
if(!string.IsNullOrEmpty(s))
{
   //remove any whitespace to the left and right of the string
   s = s.Trim();
   // Here we use a regular expression, \s+
   // This means split on any occurrence of one or more consecutive whitespaces.
   // String.Split does not contain an overload that allows you to use regular expressions
   return System.Text.RegularExpressions.Regex.Split(s, "\\s+")[position];
}
else { return null; }
