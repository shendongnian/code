        class Test
        {
            /*
             create appdomain as usually
            */
            public static object Execute(AppDomain appDomain, Type type, string method, params object[] parameters)
            {
                var call = new CallObject(type, method, parameters);
                appDomain.DoCallBack(call.Execute);
                return call.GetResult();
            }
        }
        [Serializable]
        public class CallObject
        {
            internal CallObject(Type type, string method, object[] parameters)
            {
                this.type = type;
                this.method = method;
                this.parameters = parameters;
            }
            [PermissionSet(SecurityAction.Assert, Unrestricted = true)]
            public void Execute()
            {
                object instance = Activator.CreateInstance(this.type);
                MethodInfo target = this.type.GetMethod(this.method);
                this.result.Data = target.Invoke(instance, this.parameters);
            }
            internal object GetResult()
            {
                return result.Data;
            }
            private readonly string method;
            private readonly object[] parameters;
            private readonly Type type;
            private readonly CallResult result = new CallResult();
            private class CallResult : MarshalByRefObject
            {
                internal object Data { get; set; }
            }
        }
