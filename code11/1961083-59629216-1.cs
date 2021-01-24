    public static class Extensions
    {
        /// <summary>
        /// Returns all Details of an exception
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static string GetDetails(this Exception exception)
        {
            string GetInnerExceptionDetails(Exception e)
            {
                var s = new StringBuilder(e.GetType().FullName);
                if (e.GetType().GetProperties()
                     .Select(prop => new { prop.Name, Value = prop.GetValue(e, null) })
                     .Select(x => $"{x.Name}: {x.Value ?? string.Empty}").ToList() is List<string> props && props.Any())
                {
                    s.AppendLine(string.Join(Environment.NewLine, props));
                    s.AppendLine();
                }
                if (e.InnerException != null)
                    s.AppendLine(GetInnerExceptionDetails(e.InnerException));
                return s.ToString();
            }
            return GetInnerExceptionDetails(exception);
        }
    }
