    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using Omu.ValueInjecter;
    
    namespace ConsoleApplication7
    {
        public class FromExpando : KnownSourceValueInjection<ExpandoObject>
        {
            protected override void Inject(ExpandoObject source, object target)
            {
                var d = source as IDictionary<string, object>;
                if (d == null) return;
                var tprops = target.GetProps();
    
                foreach (var o in d)
                {
                    var tp = tprops.GetByName(o.Key);
                    if (tp == null) continue;
                    tp.SetValue(target, o.Value);
                }
            }
        }
    
        public class Foo
        {
            public string Name { get; set; }
            public int Ace { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                dynamic x = new ExpandoObject();
                x.Ace = 1231;
                x.Name = "hi";
                var f = new Foo();
                //f.InjectFrom<FromExpando>((object) x); // edit:compilation error
                new FromExpando().Map((object)x,f);
                Console.WriteLine(f.Ace);
                Console.WriteLine(f.Name);
            }
        }
    } 
