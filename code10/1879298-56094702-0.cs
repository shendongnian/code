    using System;
    using PostSharp.Aspects;
    
    namespace ConsoleApp
    {
        class Program
        {    
            static void Main(string[] args)
            {
                var someClass = new SomeClass();
                Console.WriteLine($"{nameof(someClass.Value)} = {someClass.Value}");
                someClass.Value = 42;
                Console.WriteLine($"{nameof(someClass.Value)} = {someClass.Value}");
            }
        }
    
        class SomeClass
        {
            public int Value { get; [Decorate] set; }
    
            private void SomeFunction()
            {
                Console.WriteLine("SomeFunction called");
            }
    
            [Serializable, AttributeUsage(AttributeTargets.Method)]
            public class DecorateAttribute : MethodInterceptionAspect
            {
                public override void OnInvoke(MethodInterceptionArgs args)
                {
                    var target = (SomeClass)args.Instance;
                    target.SomeFunction();
    
                    args.Proceed(); // performs the method it applied to
                }
            }
        }
    }
