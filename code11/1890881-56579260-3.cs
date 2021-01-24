    using System;
    using System.Reflection;
    
    namespace Engine
    {
        public class Engine1
        {
            public Engine1()
            {
                var clientAction = Activator.CreateInstance(
                    Type.GetType("Client.ClientAction, Client"), new object[] { });
                MethodInfo methodInfo = clientAction.GetType().GetMethod("OpenForm");
                var arg1 = new object();
                var arg2 = new object();
                methodInfo.Invoke(clientAction, new object[] { arg1, arg2 });
            }
        }
    }
