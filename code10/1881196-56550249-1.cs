    using System;
    using System.Linq;
    using Mono.Cecil;
    using Mono.Cecil.Cil;
    
    namespace CecilRetrieveInitializer
    {
        class Program
        {
            static Program()
            {
                Console.WriteLine("In cctor..");
            }
    
            static void Main(string[] args)
            {
                using (var a = AssemblyDefinition.ReadAssembly(typeof(Program).Assembly.Location))
                {
                    var t = a.MainModule.GetType("CecilRetrieveInitializer.Program");
                    var f = t.Fields.SingleOrDefault(c => c.Name == "value");
                    Console.WriteLine(InitialValue(t, f));
                    Console.WriteLine(InitialValue(t, t.Fields.SingleOrDefault(c => c.Name == "value2")));
                }
    
                string InitialValue(TypeDefinition t, FieldDefinition f)
                {
                    var cctor = t.Methods.SingleOrDefault(m => m.Name == ".cctor");
                    if (cctor == null)
                        throw new Exception("no field initialization...");
    
                    var store = cctor.Body.Instructions.SingleOrDefault(i => i.OpCode == OpCodes.Stsfld && i.Operand == f);
                    if (store.Previous.Operand.GetType() != typeof(string))
                        return store.Previous.Operand.ToString();
    
                    return (string) store.Previous.Operand;
                }
            }
    
            static string MyFunction() => "Bar";
    
            public static string value = "Foo";
            public static string value2 = MyFunction();
            public const string value3 = "Bar";
        }
    }
