    // just paste this into a Console App
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Reflection.Emit;
    
    class Program
    {
        static void Main(string[] args)
        {
            // Here's the usage of a "traditional" factory, which returns objects that implement a common interface.
            // This is a great pattern for a lot of different scenarios.
            // The only downside is that you have to update your factory class whenever you add a new class.
            TraditionalFactory.Create("A_ID").DoIt();
            TraditionalFactory.Create("B_ID").DoIt();        
            Console.ReadKey();
    
            // But what if we make a class that uses reflection to find attributes of classes it can create? Reflection!
            // This works great and now all we have to do is add an attribute to new classes and this thing will just work.
            // (It could also be more generic in its input / output, but I simplified it for this example)
            ReflectionFactory.Create("A_ID").DoIt();
            ReflectionFactory.Create("B_ID").DoIt();
            // Wait, that's great and all, but everyone always says reflection is so slow, and this thing's going to reflect 
            // on every object creation...that's not good right?
            Console.ReadKey();
    
            // So I created this new factory class which gives the speed of the traditional factory combined with the flexibility 
            // of the reflection-based factory.
            // The reflection done here is only performed once. After that, it is as if the Create() method is using a switch statement        
            Factory<string, IDoSomething>.Create("A_ID").DoIt();
            Factory<string, IDoSomething>.Create("B_ID").DoIt();
    
            Console.ReadKey();
        }
    }
    
    class TraditionalFactory
    {
        public static IDoSomething Create(string id)
        {
            switch (id)
            {
                case "A_ID":
                    return new A();
                case "B_ID":
                    return new B();
                default:
                    throw new InvalidOperationException("Invalid factory identifier");
            }
        }
    }
    
    class ReflectionFactory
    {
        private readonly static Dictionary<string, Type> ReturnableTypes;
    
        static ReflectionFactory()
        {
            ReturnableTypes = GetReturnableTypes();
        }
    
        private static Dictionary<string, Type> GetReturnableTypes()
        {
            // get a list of the types that the factory can return
            // criteria for matching types:
            // - must have a parameterless constructor
            // - must have correct factory attribute, with non-null, non-empty value
            // - must have correct BaseType (if OutputType is not generic)
            // - must have matching generic BaseType (if OutputType is generic)
    
            Dictionary<string, Type> returnableTypes = new Dictionary<string, Type>();
    
            Type outputType = typeof(IDoSomething);
            Type factoryLabelType = typeof(FactoryAttribute);
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                string assemblyName = assembly.GetName().Name;
                if (!assemblyName.StartsWith("System") &&
                    assemblyName != "mscorlib" &&
                    !assemblyName.StartsWith("Microsoft"))
                {
                    foreach (Type type in assembly.GetTypes())
                    {
                        if (type.GetCustomAttributes(factoryLabelType, false).Length > 0)
                        {
                            foreach (object label in ((FactoryAttribute)type.GetCustomAttributes(factoryLabelType, true)[0]).Labels)
                            {
                                if (label != null && label.GetType() == typeof(string))
                                {
                                    if (outputType.IsAssignableFrom(type))
                                    {
                                        returnableTypes.Add((string)label, type);
                                    }
                                }
                            }
                        }
                    }
                }
            }
    
            return returnableTypes;
        }
    
        public static IDoSomething Create(string id)
        {
            if (ReturnableTypes.ContainsKey(id))
            {
                return (IDoSomething)Activator.CreateInstance(ReturnableTypes[id]);
            }
            else
            {
                throw new Exception("Invalid factory identifier");
            }
        }
    }
    
    [Factory("A_ID")]
    class A : IDoSomething
    {
        public void DoIt()
        {
            Console.WriteLine("Letter A");
        }
    }
    
    [Factory("B_ID")]
    class B : IDoSomething
    {
        public void DoIt()
        {
            Console.WriteLine("Letter B");
        }
    }
    
    public interface IDoSomething
    {
        void DoIt();
    }
    
    /// <summary>
    /// Attribute class for decorating classes to use with the generic Factory
    /// </summary>
    public sealed class FactoryAttribute : Attribute
    {
        public IEnumerable<object> Labels { get; private set; }
        public FactoryAttribute(params object[] labels)
        {
            if (labels == null)
            {
                throw new ArgumentNullException("labels cannot be null");
            }
            Labels = labels;
        }
    }
    
    /// <summary>
    /// Custom exception class for factory creation errors
    /// </summary>
    public class FactoryCreationException : Exception
    {
        public FactoryCreationException()
            : base("Factory failed to create object")
        {
        }
    }
    
    /// <summary>
    /// Generic Factory class.  Classes must have a parameterless constructor for use with this class.  Decorate classes with 
    /// <c>FactoryAttribute</c> labels to match identifiers
    /// </summary>
    /// <typeparam name="TInput">Input identifier, matches FactoryAttribute labels</typeparam>
    /// <typeparam name="TOutput">Output base class / interface</typeparam>
    public class Factory<TInput, TOutput>
        where TOutput : class
    {
        private static readonly Dictionary<TInput, int> JumpTable;
        private static readonly Func<TInput, TOutput> Creator;
    
        static Factory()
        {
            JumpTable = new Dictionary<TInput, int>();
            Dictionary<TInput, Type> returnableTypes = GetReturnableTypes();
            int index = 0;
            foreach (KeyValuePair<TInput, Type> kvp in returnableTypes)
            {
                JumpTable.Add(kvp.Key, index++);
            }
            Creator = CreateDelegate(returnableTypes);
        }
    
        /// <summary>
        /// Creates a TOutput instance based on the label
        /// </summary>
        /// <param name="label">Identifier label to create</param>
        /// <returns></returns>
        public static TOutput Create(TInput label)
        {
            return Creator(label);
        }
    
        /// <summary>
        /// Creates a TOutput instance based on the label
        /// </summary>
        /// <param name="label">Identifier label to create</param>
        /// <param name="defaultOutput">default object to return if creation fails</param>
        /// <returns></returns>
        public static TOutput Create(TInput label, TOutput defaultOutput)
        {
            try
            {
                return Create(label);
            }
            catch (FactoryCreationException)
            {
                return defaultOutput;
            }
        }
    
        private static Dictionary<TInput, Type> GetReturnableTypes()
        {
            // get a list of the types that the factory can return
            // criteria for matching types:
            // - must have a parameterless constructor
            // - must have correct factory attribute, with non-null, non-empty value
            // - must have correct BaseType (if OutputType is not generic)
            // - must have matching generic BaseType (if OutputType is generic)
    
            Dictionary<TInput, Type> returnableTypes = new Dictionary<TInput, Type>();
    
            Type outputType = typeof(TOutput);
            Type factoryLabelType = typeof(FactoryAttribute);
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                string assemblyName = assembly.GetName().Name;
                if (!assemblyName.StartsWith("System") &&
                    assemblyName != "mscorlib" &&
                    !assemblyName.StartsWith("Microsoft"))
                {
                    foreach (Type type in assembly.GetTypes())
                    {
                        if (type.GetCustomAttributes(factoryLabelType, false).Length > 0)
                        {
                            foreach (object label in ((FactoryAttribute)type.GetCustomAttributes(factoryLabelType, true)[0]).Labels)
                            {
                                if (label != null && label.GetType() == typeof(TInput))
                                {
                                    if (outputType.IsAssignableFrom(type))
                                    {
                                        returnableTypes.Add((TInput)label, type);
                                    }
                                }
                            }
                        }
                    }
                }
            }
    
            return returnableTypes;
        }
    
        private static Func<TInput, TOutput> CreateDelegate(Dictionary<TInput, Type> returnableTypes)
        {
            // get FieldInfo reference to the jump table dictionary
            FieldInfo jumpTableFieldInfo = typeof(Factory<TInput, TOutput>).GetField("JumpTable", BindingFlags.Static | BindingFlags.NonPublic);
            if (jumpTableFieldInfo == null)
            {
                throw new InvalidOperationException("Unable to get jump table field");
            }
    
            // set up the IL Generator
            DynamicMethod dynamicMethod = new DynamicMethod(
                "Magic",                                        // name of dynamic method
                typeof(TOutput),                                // return type
                new[] { typeof(TInput) },                        // arguments
                typeof(Factory<TInput, TOutput>),                // owner class
                true);
            ILGenerator gen = dynamicMethod.GetILGenerator();
    
            // define labels (marked later as IL is emitted)
            Label creationFailedLabel = gen.DefineLabel();
            Label[] jumpTableLabels = new Label[JumpTable.Count];
            for (int i = 0; i < JumpTable.Count; i++)
            {
                jumpTableLabels[i] = gen.DefineLabel();
            }
    
            // declare local variables
            gen.DeclareLocal(typeof(TOutput));
            gen.DeclareLocal(typeof(TInput));
            LocalBuilder intLocalBuilder = gen.DeclareLocal(typeof(int));
    
            // emit MSIL instructions to the dynamic method
            gen.Emit(OpCodes.Ldarg_0);
            gen.Emit(OpCodes.Stloc_1);
            gen.Emit(OpCodes.Volatile);
            gen.Emit(OpCodes.Ldsfld, jumpTableFieldInfo);
            gen.Emit(OpCodes.Ldloc_1);
            gen.Emit(OpCodes.Ldloca_S, intLocalBuilder);
            gen.Emit(OpCodes.Call, typeof(Dictionary<TInput, int>).GetMethod("TryGetValue"));
            gen.Emit(OpCodes.Brfalse, creationFailedLabel);
            gen.Emit(OpCodes.Ldloc_2);
            // execute the MSIL switch statement
            gen.Emit(OpCodes.Switch, jumpTableLabels);
    
            // set up the jump table
            foreach (KeyValuePair<TInput, int> kvp in JumpTable)
            {
                gen.MarkLabel(jumpTableLabels[kvp.Value]);
                // create the type to return
                gen.Emit(OpCodes.Newobj, returnableTypes[kvp.Key].GetConstructor(Type.EmptyTypes));
                gen.Emit(OpCodes.Ret);
            }
    
            // CREATION FAILED label
            gen.MarkLabel(creationFailedLabel);
            gen.Emit(OpCodes.Newobj, typeof(FactoryCreationException).GetConstructor(Type.EmptyTypes));
            gen.Emit(OpCodes.Throw);
    
            // create a delegate so we can later invoke the dynamically created method
            return (Func<TInput, TOutput>)dynamicMethod.CreateDelegate(typeof(Func<TInput, TOutput>));
        }
    }
