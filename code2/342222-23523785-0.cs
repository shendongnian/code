    using System.Reflection;
        public class JsException : Exception
        {
            static readonly FieldInfo _stackTraceString = typeof(Exception).GetField("_stackTraceString", BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
            public JsException(string error, string stack)
                : base(error)
            {
                _stackTraceString.SetValue(this, stack);
            }
        }
