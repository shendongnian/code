        public string Compile(string param1, string param2)
        {
            // some codes here ****
            var pattern = @"@\{.*?}+";
            var objects = new List<Class1>();
            var result = Regex.Replace(param1, pattern, m =>
            {
                var r = MethodToMatch(m, param2, out var paramObject);
                objects.Add(paramObject);
                return r;
            });
            OnActionCompleted(paramObjects);
            return result;
        }
Learn more about closures in .net
