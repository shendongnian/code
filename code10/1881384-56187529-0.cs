    class ParserCompiler
    {
        private static (string format, IReadOnlyCollection<string> propertyNames) Parse(string text)
        {
            var regex = new Regex(@"(.*?)\[(.+?)\](.*)");
            var formatTemplate = new StringBuilder();
            var propertyNames = new List<string>();
            var restOfText = text;
            Match match;
            while ((match = regex.Match(restOfText)).Success)
            {
                formatTemplate.Append(match.Groups[1].Value);
                formatTemplate.Append("{");
                formatTemplate.Append(propertyNames.Count);
                formatTemplate.Append("}");
                propertyNames.Add(match.Groups[2].Value);
                restOfText = match.Groups[3].Value;
            }
            formatTemplate.Append(restOfText);
            return (formatTemplate.ToString(), propertyNames);
        }
        public static Func<T, string> GetExpression<T>(string text) //"[Id]-[Description]"
        {
            var parsed = Parse(text); //"{0}-{1}  Id, Description"
            var argumentExpression = Expression.Parameter(typeof(T));
            var properties = typeof(T)
                .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetField)
                .ToDictionary(keySelector: propInfo => propInfo.Name);
            var formatParamsArrayExpr = Expression.NewArrayInit(
                typeof(object), 
                parsed.propertyNames.Select(propName => Expression.Property(argumentExpression, properties[propName])));
            
            var formatStaticMethod = typeof(string).GetMethod("Format", BindingFlags.Static | BindingFlags.Public, null,new[] { typeof(string), typeof(object[]) }, null);
            var formatExpr = Expression.Call(
                formatStaticMethod,
                Expression.Constant(parsed.format, typeof(string)),
                formatParamsArrayExpr);
            var resultExpr = Expression.Lambda<Func<T, string>>(
                formatExpr,
                argumentExpression); // Expression<Func<Foo, string>> a = (Foo x) => string.Format("{0}-{1}", x.Id, x.Description);
            return resultExpr.Compile();
        }
    }
