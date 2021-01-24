    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ExcelDna.Integration;
    using ExcelDna.Documentation;
    
    namespace Excel_DNA_Library
    {
        /// <summary>
        /// This code is only used as test case for Excel-DNA and Sandcastle XML-comments.
        /// </summary>
        /// <remarks>
        /// <para>This class can welcome you and add.</para>
        /// <para>Nothing else is possible.</para>
        /// </remarks>
        public class UDFHelper
        {
            /// <summary>
            /// <c>MyHelloWorld</c> - my first .NET function using Excel-DNA.
            /// </summary>
            /// <param name="name">Your first name.</param>/// 
            /// <returns>A welcome string and text from user input.</returns>
            /// <example>
            /// <code>
            /// =MyHelloWorld("www.help-info.de");
            /// </code>
            /// </example>
            [ExcelFunction( Name = "MyHelloWorld",
                            Category = "Text",
                            Description = "Welcome - my first .NET function using Excel-DNA.",
                            HelpTopic = "Excel-DNA-Library-AddIn.chm!10000")]
    
            public static string SayHello(string name)
            {
                return "You are welcome " + name;
            }
    
            /// <summary>
            /// <c>MyAddTwoIntegers</c> - my second .NET function using Excel-DNA.
            /// </summary>
            /// <param name="a">The first integer.</param>
            /// <param name="b">The second integer.</param>
            /// <returns>The sum of two integers.</returns>
            /// <example>
            /// <code>
            /// =MyAddTwoIntegers(4, 5);
            /// </code>
            /// </example>
            [ExcelFunctionDoc(Name = "MyAddTwoIntegers",
                              Category = "Math",
                              Description = "Add two integers - my second .NET function using Excel-DNA.",
                              HelpTopic = "Excel-DNA-Library-AddIn.chm!20000",
                              Summary = "really all it does is add two number ... I promise.",
                              Returns = "the sum of the two arguments")]            
               
            public static int Add(int a, int b)
            {
                return a + b;
            }
    
        }
    }
