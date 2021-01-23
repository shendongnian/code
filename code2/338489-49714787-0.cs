    using System;
    namespace StackoverflowConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
              Console.WriteLine(StringExtensionMethods.EnsureEndsWithDot("abc"));
            }
        }
    }
    namespace StackoverflowConsoleApp
    {
        /// <summary>
        /// This class contains string extensions
        /// </summary>
        public static class StringExtensionMethods
        {
            /// <summary>
            /// constant dot
            /// </summary>
            private const string dot = ".";
            /// <summary>
            /// Ensures the string ends with dot character
            /// </summary>
            /// <param name="text"><see cref="string"/>Takes a string parameter</param>
            /// <returns><see cref="string"/>returns a string parameter</returns>
            public static string EnsureEndsWithDot(this string text)
            {
                if (!text.EndsWith(dot))
                {
                    return string.Format("{0}{1}", text, dot);
                }
                return text;
            }
        }
    }
