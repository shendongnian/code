    using System;
    using System.Diagnostics;
    using System.Dynamic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication {
        public static class ConsoleApp {
            public static void Main() {
                dynamic x = new MyDynamicObject();
                var result = x("awe", "some");
            
                Debug.Assert(result == "awesome");
            }
        }
        public class MyDynamicObject : DynamicObject {
            public override Boolean TryInvoke(InvokeBinder binder, Object[] args, out Object result) {
                result = args.Aggregate(new StringBuilder(), (builder, item) => builder.Append(item), builder => builder.ToString());
                return true;
            }
        }
    }
