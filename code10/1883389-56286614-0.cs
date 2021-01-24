        public static bool Is<T>(this MethodInfo self, Expression<Action<T>> selector, bool strict = false)
        {
            var body = (selector.Body as MethodCallExpression);
            if (body == null) return false;
            var methodName = body.Method.Name;
            if (self.Name != methodName) return false;
            if (strict && self.ReflectedType != body.Method.ReflectedType) return false;
            var parameterInfos = body.Method.GetParameters();
            var parameterCount = parameterInfos.Length;
            var parameters = self.GetParameters();
            if (parameters.Length != parameterCount) return false;
            return !parameters.Where((t, i) =>
                t.ParameterType != parameterInfos[i].ParameterType).Any();
        }
