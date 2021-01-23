    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                   // all of these don't work
                Console.WriteLine("{0:C}", 10);
                Console.WriteLine("{0:00.0}", 10);
                Console.WriteLine("{0:0}", 10);
                Console.WriteLine("{0:0.00}", 10);
                Console.WriteLine("{0:0}", 10.0);
                Console.WriteLine("{0:0}", 10.1);
                Console.WriteLine("{0:0.00}", 10.1);
      
              // works
                Console.WriteLine(String.Format(new MyFormatter(),"{0:custom}", 9));
                Console.WriteLine(String.Format(new MyFormatter(),"{0:custom}", 9.1));
                Console.ReadKey();
            }
        }
    
        class MyFormatter : IFormatProvider, ICustomFormatter
        {
            public string Format(string format, object arg, IFormatProvider formatProvider)
            {
                switch (format.ToUpper())
                {
                    case "CUSTOM":
                        if (arg is short || arg is int || arg is long)
                            return arg.ToString();
                        if (arg is Single || arg is Double)
                            return String.Format("{0:0.00}",arg);
                        break;
                    // Handle other
                    default:
                        try
                        {
                            return HandleOtherFormats(format, arg);
                        }
                        catch (FormatException e)
                        {
                            throw new FormatException(String.Format("The format of '{0}' is invalid.", format), e);
                        }
                }
                return arg.ToString(); // only as a last resort
            }
    
            private string HandleOtherFormats(string format, object arg)
            {
                if (arg is IFormattable)
                    return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
                if (arg != null)
                    return arg.ToString();
                return String.Empty;
            }
    
            public object GetFormat(Type formatType)
            {
                if (formatType == typeof(ICustomFormatter))
                    return this;
                return null;
            }
        }
    }
