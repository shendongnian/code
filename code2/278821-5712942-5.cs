    // Custom attribute to set message ID
    class WinMessageHandler : System.Attribute
    {
        public int Msg;
        public WinMessageHandler(int Msg) { this.Msg = Msg; }
    }    
    
    class WinMessageDispatcher
    {
        
        // This is cached for the life of the application, it holds the required per-type
        // dispatching information.
        private class WinMessageDispatcher_PerType
        {
            private Dictionary<int, System.Reflection.MethodInfo> dict;
            // generic handler
            public bool HandleMessage(object OnInstance, ref Message msg)
            {
                System.Reflection.MethodInfo method;
                if (dict.TryGetValue(msg.Msg, out method))
                {
                    // Set up the call
                    object[] p = new object[1];
                    p[0] = msg;
                    return (bool)method.Invoke(OnInstance, p);
                    msg = p[0];
                }
                else
                {
                    return false;
                }
            }
            // Constructor, initializes the "dict"
            public WinMessageDispatcher_PerType(Type t)
            {
                dict = new Dictionary<int, System.Reflection.MethodInfo>();
                foreach (var method in t.GetMethods())
                {
                    var attribs = method.GetCustomAttributes(typeof(WinMessageHandler), true);
                    if (attribs.Length > 0)
                    {
                        // Check return type
                        if (method.ReturnParameter.ParameterType != typeof(bool)) throw new Exception(string.Format("{0} doesn't return bool", method.Name));
                        // Check method parameters
                        var param = method.GetParameters();
                        if (param.Length != 1) throw new Exception(string.Format("{0} doesn't take 1 parameter", method.Name));
                        // Ooops! How do I check the TYPE of the "ref" parameter?
                        if (!param[0].ParameterType.IsByRef) throw new Exception(string.Format("{0} doesn't take a ref parameter of type System.Windows.Forms.Message but a parameter of type {1}", method.Name, param[0].ParameterType.ToString()));
                        // Add the method to the dictionary
                        dict.Add(((WinMessageHandler)attribs[0]).Msg, method);
                    }
                }
            }
        }
        // Dictionary to link "Types" to per-type cached implementations
        private static Dictionary<Type, WinMessageDispatcher_PerType> dict;
        // Static type initializer
        static WinMessageDispatcher()
        {
            dict = new Dictionary<Type, WinMessageDispatcher_PerType>();
        }
        // Message dispatcher
        public static bool Dispatch(object ObjInstance, ref Message msg)
        {
            if (ObjInstance == null) return false;
            else
            {
                WinMessageDispatcher_PerType PerType;
                lock (dict)
                {
                    if (!dict.TryGetValue(ObjInstance.GetType(), out PerType))
                    {
                        PerType = new WinMessageDispatcher_PerType(ObjInstance.GetType());
                        dict.Add(ObjInstance.GetType(), PerType);
                    }
                }
                return PerType.HandleMessage(ObjInstance, ref msg);
            }
        }
        
    }
