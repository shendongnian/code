    // example usage:
    // try{ ... } catch(Exception e) { MessageBox.Show(e.ToFormattedString()); }
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace YourNamespace
    {
        public static class ExceptionExtensions
        {
    
            public static IEnumerable<Exception> GetAllExceptions(this Exception exception)
            {
                yield return exception;
    
                if (exception is AggregateException )
                {
                    var aggrEx = exception as AggregateException;
                    foreach (Exception innerEx in aggrEx.InnerExceptions.SelectMany(e => e.GetAllExceptions()))
                    {
                        yield return innerEx;
                    }
                }
                else if (exception.InnerException != null)
                {
                    foreach (Exception innerEx in exception.InnerException.GetAllExceptions())
                    {
                        yield return innerEx;
                    }
                }
            }
    
    
            public static string ToFormattedString(this Exception exception)
            {
                IEnumerable<string> messages = exception
                    .GetAllExceptions()
                    .Where(e => !String.IsNullOrWhiteSpace(e.Message))
                    .Select(e => e.Message.Trim() + "\r\n" + (e.StackTrace!=null?StackTrace.Trim():"") );
                string flattened = String.Join("\r\n\r\n", messages); // <-- the separator here
                return flattened;
            }
        }
    }
