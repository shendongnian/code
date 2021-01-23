    namespace ParamsTest {
        interface Foo {
            void M<T>(string s, int n, params object[] objects);
        }
        class Bar : Foo {
            public void M<T>(string s, int n, params object[] objects) {
                Console.WriteLine(s);
                Console.WriteLine(n);
                Console.WriteLine(objects == null);
                Console.WriteLine(typeof(T).Name);
            }
        }
        internal class Program {
            internal static void Main(string[] args) {
                var genericMethodInfo =
                    typeof(Foo).GetMethods()
                        .Where(m => m.Name == "M")
                        .Where(m => m.GetParameters()
                           .Select(p => p.ParameterType)
                           .SequenceEqual(new[] {
                               typeof(string),
                               typeof(int),
                               typeof(object[])
                           })
                    )
                    .SingleOrDefault();
                var methodInfo =
                    genericMethodInfo.MakeGenericMethod(
                        new[] { typeof(DateTime) }
                    );
                var bar = new Bar();
                methodInfo.Invoke(bar, new object[] { "Hello, world!", 17, null });
            }
        }
    }
