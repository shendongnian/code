    // SqlRegularExpressions.cs
    // © Copyright 2009, Roman Khramtsov / Major League - SqlRegularExpressions
    
    using System;
    using System.Data.SqlTypes;			//SqlChars
    using System.Collections;			//IEnumerable
    using System.Text.RegularExpressions;	//Match, Regex
    using Microsoft.SqlServer.Server;		//SqlFunctionAttribute
    
    /// <summary>
    /// Class that allows to support regular expressions in MS SQL Server 2005/2008
    /// </summary>
    public partial class SqlRegularExpressions
    {
    	/// <summary>
    	/// Checks string on match to regular expression
    	/// </summary>
    	/// <param name="text">string to check</param>
    	/// <param name="pattern">regular expression</param>
    	/// <returns>true - text consists match one at least, false - no matches</returns>
        [SqlFunction]
        public static bool Like(string text, string pattern, int options)
        {
            return (Regex.IsMatch(text, pattern, (RegexOptions)options));
        }
    
    	/// <summary>
    	/// Gets matches from text using pattern
    	/// </summary>
    	/// <param name="text">text to parse</param>
    	/// <param name="pattern">regular expression pattern</param>
    	/// <returns>MatchCollection</returns>
        [SqlFunction(FillRowMethodName = "FillMatch")]
        public static IEnumerable GetMatches(string text, string pattern, int options)
        {
            return Regex.Matches(text, pattern, (RegexOptions)options);
        }
    
        /// <summary>
        /// Parses match-object and returns its parameters 
        /// </summary>
        /// <param name="obj">Match-object</param>
        /// <param name="index">TThe zero-based starting position in the original string where the captured
        ///     substring was found</param>
        /// <param name="length">The length of the captured substring.</param>
        /// <param name="value">The actual substring that was captured by the match.</param>
        public static void FillMatch(object obj, out int index, out int length, out SqlChars value)
        {
            Match match = (Match)obj;
            index = match.Index;
            length = match.Length;
            value = new SqlChars(match.Value);
        }
    
    }
