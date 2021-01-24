using System.Xml;
static public class StringHelper
{
  static public bool ContainsOnlyNumbers(this string text)
  {
    foreach ( var item in text.SplitByWhiteSpaceAndNewLine() )
      if ( !double.TryParse(item, out var value) )  // or decimal.TryParse
        return false;
    return true;
  }
  static public bool ContainsOnlyNumbersThatCanHavePoint(this string text)
  {
    foreach ( var item in text.SplitByWhiteSpaceAndNewLine() )
      try
      {
        XmlConvert.ToDouble(item);  // or XmlConvert.ToDecimal
      }
      catch
      {
        return false;
      }
    return true;
  }
  static public List<string> SplitByWhiteSpaceAndNewLine(this string text)
  {
    string str = text.Replace(Environment.NewLine, " ");
    var words = new List<string>();
    var builder = new StringBuilder();
    char charCurrent;
    Action processBuilder = () =>
    {
      var word = builder.ToString();
      if ( !string.IsNullOrEmpty(word) )
        words.Add(word);
    };
    for ( int index = 0; index < str.Length; index++ )
    {
      charCurrent = str[index];
      if ( !char.IsWhiteSpace(charCurrent) )
        builder.Append(charCurrent);
      else
      {
        processBuilder();
        builder.Clear();
      }
    }
    processBuilder();
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
      "1 75 3,2",
      "1 75 3.2",
      @"1 2 
        4,5 72",
      @"1 2 
        4.5 72"
    };
    Action<Func<string, bool>, string> test = ( action, str ) =>
    {
      foreach ( string item in list )
      {
        if ( action(item) )
          Console.WriteLine($"\"{item}\" contains only numbers that can have {str} separator.");
        else
          Console.WriteLine($"\"{item}\" contains some non numbers.");
      }
    };
    test(StringHelper.ContainsOnlyNumbers, "decimal");
    Console.WriteLine();
    test(StringHelper.ContainsOnlyNumbersThatCanHavePoint, "point");
**Output**
"1 2 4,5 72" contains only numbers that can have decimal separator.
"1 2 4.5 72" contains some non numbers.
"1      2 4.5 72" contains some non numbers.
"1 7..5 3.2.1" contains some non numbers.
"1 75 3,2" contains only numbers that can have decimal separator.
"1 75 3.2" contains some non numbers.
"1 2
        4,5 72" contains only numbers that can have decimal separator.
"1 2
        4.5 72" contains some non numbers.
"1 2 4,5 72" contains some non numbers.
"1 2 4.5 72" contains only numbers that can have point separator.
"1      2 4.5 72" contains only numbers that can have point separator.
"1 7..5 3.2.1" contains some non numbers.
"1 75 3,2" contains some non numbers.
"1 75 3.2" contains only numbers that can have point separator.
"1 2
        4,5 72" contains some non numbers.
"1 2
        4.5 72" contains only numbers that can have point separator.
**To get all numbers**
public enum DecimalSeparator
{
  Localized,
  Point
}
static public class StringHelper
{
  static public bool ContainsOnlyNumbers(this string text)
  {
    return text.ContainsOnlyNumbers(DecimalSeparator.Localized);
  }
  static public List<double> GetAllNumbers(this string text, DecimalSeparator separator)
  {
    var list = new List<double>();
    switch ( separator )
    {
      case DecimalSeparator.Localized:
        foreach ( var item in text.SplitByWhiteSpaceAndNewLine() )
          if ( double.TryParse(item, out var value) )
            list.Add(value);
        break;
      case DecimalSeparator.Point:
        foreach ( var item in text.SplitByWhiteSpaceAndNewLine() )
          try
          {
            list.Add(XmlConvert.ToDouble(item));
          }
          catch
          {
          }
        break;
      default:
        throw new NotImplementedException();
    }
    return list;
  }
}
