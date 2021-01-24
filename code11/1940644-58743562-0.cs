using System.Xml;
static public class StringHelper
{
  static public bool ContainsOnlyNumbers(this string text)
  {
    foreach ( var item in text.SplitByWhiteSpace() )
      if ( !double.TryParse(item, out var value) )
        return false;
    return true;
  }
  static public bool ContainsOnlyNumbersHavingPoint(this string text)
  {
    foreach ( var item in text.SplitByWhiteSpace() )
      try
      {
        XmlConvert.ToDouble(item);
      }
      catch
      {
        return false;
      }
    return true;
  }
  static public List<string> SplitByWhiteSpace(this string text)
  {
    string str = text.Replace(Environment.NewLine, " ");
    var builder = new StringBuilder();
    char charCurrent;
    var words = new List<string>();
    for ( int index = 0; index < str.Length; index++ )
    {
      charCurrent = str[index];
      if ( !char.IsWhiteSpace(charCurrent) )
        builder.Append(charCurrent);
      else
      {
        var word = builder.ToString();
        if ( !string.IsNullOrEmpty(word) )
          words.Add(word);
        builder.Clear();
      }
    }
    return words;
  }
}
**Test**
    var list = new string[]
    {
      "1 2 4,5 72",
      "1 2 4.5 72",
      "1	2 4.5 72",
      "1 7..5 3.2.1",
      @"1 2 
        4.5 72"
    };
    Action<Func<string, bool>, string> test = ( action, str ) =>
    {
      foreach ( string item in list )
      {
        if ( action(item) )
          Console.WriteLine($"\"{item}\" contains only numbers occurences having {str} separator.");
        else
          Console.WriteLine($"\"{item}\" contains some non numbers occurences.");
      }
    };
    test(StringHelper.ContainsOnlyNumbers, "decimal");
    Console.WriteLine();
    test(StringHelper.ContainsOnlyNumbersHavingPoint, "point");
**Output**
"1 2 4,5 72" contains only numbers occurences having decimal separator.
"1 2 4.5 72" contains some non numbers occurences.
"1      2 4.5 72" contains some non numbers occurences.
"1 7..5 3.2.1" contains some non numbers occurences.
"1 2
        4.5 72" contains some non numbers occurences.
"1 2 4,5 72" contains some non numbers occurences.
"1 2 4.5 72" contains only numbers occurences having point separator.
"1      2 4.5 72" contains only numbers occurences having point separator.
"1 7..5 3.2.1" contains some non numbers occurences.
"1 2
        4.5 72" contains only numbers occurences having point separator.
