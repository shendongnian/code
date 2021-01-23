        public static void Trace()
        {
            var method = new System.Diagnostics.StackTrace(1, false).GetFrame(0).GetMethod();
            var fromType = method.DeclaringType;
            if (method.Name.Contains("."))
            {
                var iname = method.Name.Substring(0, method.Name.LastIndexOf('.'));
                fromType = Type.GetType(iname); // fromType is now IFoo.
            }
        }
