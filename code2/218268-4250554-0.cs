    //  using System.Text.RegularExpressions;
    
    /// <summary>
    ///  Regular expression built for C# on: Mon, Nov 22, 2010, 03:51:18 PM
    ///  Using Expresso Version: 3.0.2766, http://www.ultrapico.com
    ///  
    ///  A description of the regular expression:
    ///  
    ///  <img src="
    ///      <img
    ///      Space
    ///      src="
    ///  Any character that is NOT in this class: ["], any number of repetitions
    ///  " alt="
    ///      "
    ///      Space
    ///      alt="
    ///  [1]: A numbered capture group. [[^"]*]
    ///      Any character that is NOT in this class: ["], any number of repetitions
    ///  ">
    ///      ">
    ///  
    ///
    /// </summary>
    public static Regex regex = new Regex(
          "<img src=\"[^\"]*\" alt=\"([^\"]*)\">",
          RegexOptions.Compiled
        );
    
    
    // This is the replacement string
    public static string regexReplace = "$1";
    
    
    //// Replace the matched text in the InputText using the replacement pattern
    // string result = regex.Replace(InputText,regexReplace);
    
    //// Split the InputText wherever the regex matches
    // string[] results = regex.Split(InputText);
    
    //// Capture the first Match, if any, in the InputText
    // Match m = regex.Match(InputText);
    
    //// Capture all Matches in the InputText
    // MatchCollection ms = regex.Matches(InputText);
    
    //// Test to see if there is a match in the InputText
    // bool IsMatch = regex.IsMatch(InputText);
    
    //// Get the names of all the named and numbered capture groups
    // string[] GroupNames = regex.GetGroupNames();
    
    //// Get the numbers of all the named and numbered capture groups
    // int[] GroupNumbers = regex.GetGroupNumbers();
