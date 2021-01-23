    public class ReflectionSample
        {
            protected void Method(int i)
            {
                Console.WriteLine(string.Format("in the world of the reflection- only {0}", i));
                Console.Read();
            }
            protected void Method(int i, int j)
            {
                Console.WriteLine(string.Format("in the world of the reflection  {0} , {1}", i,j));
                Console.Read();
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var eFlags = BindingFlags.Instance | BindingFlags.NonPublic;
                var objType = Type.GetType("Sample.ReflectionSample");
                var methods = objType.GetMethods(eFlags);
                foreach (var method in methods)
                {
                    if (method.Name == "Method")
                    {
                        Console.WriteLine("Method name is :" + method.Name);
                        var parameters = method.GetParameters();
                        int value = 10;
                        List<object> param = new List<object>();
                        for (int i = 0; i < parameters.Count(); i++)
                        {
                            param.Add(value * 5);
                        }
                        Console.WriteLine(parameters.Count());
                        method.Invoke(new ReflectionSample(), param.ToArray());
                    }
                }
            }
        }
