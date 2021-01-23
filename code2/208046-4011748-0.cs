    using System.Windows.Forms;
    using System;
    using MethodInfo = System.Reflection.MethodInfo;
    
    namespace hello
    {
        class Startup
        {
            static void Main(string[] args)
            {
                Type stringType = typeof(string);
                Type messageBoxType = typeof(MessageBox);
                Type mbButtonsType = typeof(MessageBoxButtons);
                Type[] argTypes = { stringType, stringType, mbButtonsType };
                MethodInfo showMethod = messageBoxType.GetMethod("Show", argTypes);
    
                var OkBtn = MessageBoxButtons.OK;
                TypedReference tr = __makeref(OkBtn);
                object mbOkBtn = TypedReference.ToObject(tr);
    
                object[] mbArgs = { "Hello, world!", "Reflect-app:", mbOkBtn };
    
                showMethod.Invoke(null, mbArgs);
            }
        }
    }
