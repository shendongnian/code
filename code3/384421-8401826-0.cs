    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection.Emit;
    using System.Reflection;
    
    namespace ReflectionEmit
    {
        class Program
        {
            delegate int DoMath(int value);
    
            static DoMath mathFunc;
    
            static void Main(string[] args)
            {
                CreateCode(27, true);
                CreateCode(27, false);
    
                BuildGenericType();
    
                Console.ReadKey();
            }
    
            private static void CreateCode(int value, bool square)
            {
                mathFunc = (DoMath)BuildMethod(square).CreateDelegate(typeof(DoMath));
                int result = mathFunc(value);
    
                Console.WriteLine("Result for {0} was {1}", value, result );
    
            }
    
            private static DynamicMethod BuildMethod(bool square)
            {
                Type[] methodArgs = { typeof(int) };
                DynamicMethod mthMeth = new DynamicMethod(
                    "Square",
                    typeof(int),
                    methodArgs,
                    typeof(ReflectionEmit.Program).Module);
    
                ILGenerator il = mthMeth.GetILGenerator();
    
                if (square)
                {
                    il.Emit(OpCodes.Ldarg_0); //Loads argument at index 0 into the evaluation stack
                    il.Emit(OpCodes.Conv_I8); //Converts the value on top of the evaluation stack to int64
                    il.Emit(OpCodes.Dup); //Copies the top most value on the evaluation stack, then pushes it to the top
                    il.Emit(OpCodes.Mul); //Multiplies two values then pushes result to top of evaluation stack
                    il.Emit(OpCodes.Ret); //Returns from the current method, pushing a return value (if present) from the callee's evaluation stack onto the caller's evaluation stack. 
                }
                else
                {
                    il.Emit(OpCodes.Ldarg_0); //Loads argument at index 0 into the evaluation stack
                    il.Emit(OpCodes.Conv_I8); //Converts the value on top of the evaluation stack to int64
                    il.Emit(OpCodes.Dup); //Copies the top most value on the evaluation stack, then pushes it to the top
                    il.Emit(OpCodes.Add); //Adds two values then pushes result to top of evaluation stack
                    il.Emit(OpCodes.Ret); //Returns from the current method, pushing a return value (if present) from the callee's evaluation stack onto the caller's evaluation stack.
                }
    
                return mthMeth;
            }
    
            private static void BuildGenericType()
            {
                //Define assembly
                AppDomain dom = AppDomain.CurrentDomain;
                AssemblyName asmName = new AssemblyName("domath");
                AssemblyBuilder asm = dom.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.RunAndSave);
    
                //Define a dynamic module
                ModuleBuilder mod = asm.DefineDynamicModule(asmName.Name, asmName.Name + ".dll");
    
                //Define a class
                TypeBuilder asmType = mod.DefineType("OurClass", TypeAttributes.Public);
    
                //Define the generic type parameters
                string[] typeNames = { "TFirst", "TSecond" };
                GenericTypeParameterBuilder[] genTypes = asmType.DefineGenericParameters(typeNames);
    
                GenericTypeParameterBuilder TFirst = genTypes[0];
                GenericTypeParameterBuilder TSecond = genTypes[1];
    
                //Define generic constraints
                TFirst.SetGenericParameterAttributes(GenericParameterAttributes.DefaultConstructorConstraint | GenericParameterAttributes.ReferenceTypeConstraint);
                TSecond.SetBaseTypeConstraint(typeof(SomeBaseClass));
                
                Type[] interfaceTypes = {typeof(InterfaceA), typeof(InterfaceB) };
                TSecond.SetInterfaceConstraints(interfaceTypes);
    
                //Define a field
                FieldBuilder fld1 = asmType.DefineField("Field1", TFirst, FieldAttributes.Private);
    
                //Define method
                Type listOf = typeof(List<>);
                Type listOfTFirst = listOf.MakeGenericType(TFirst);
                Type[] paramTypes = { TFirst.MakeArrayType() };
    
                MethodBuilder asmMethod = asmType.DefineMethod("SomeMethod", MethodAttributes.Public | MethodAttributes.Static, listOfTFirst, paramTypes);
    
                //Define Method Body
                ILGenerator il = asmMethod.GetILGenerator();
    
                Type ienumOf = typeof(IEnumerable<>);
                Type tFromListOf = listOf.GetGenericArguments()[0];
                Type ienumOfT = ienumOf.MakeGenericType(tFromListOf);
                Type[] ctorArgs = { ienumOfT };
    
                ConstructorInfo ctorPrep = listOf.GetConstructor(ctorArgs);
                ConstructorInfo ctor = TypeBuilder.GetConstructor(listOfTFirst, ctorPrep);
    
                il.Emit(OpCodes.Ldarg_0); //Loads the argument at index 0 onto the evaluation stack.
                il.Emit(OpCodes.Newobj, ctor); //Creates a new object or a new instance of a value type, pushing an object reference (type O) onto the evaluation stack.
                il.Emit(OpCodes.Ret); //Returns from the current method, pushing a return value (if present) from the callee's evaluation stack onto the caller's evaluation stack.
    
                //Create type and save file
                Type finished = asmType.CreateType();
                asm.Save(asmName.Name + ".dll");
    
                
    
            }
        }
    
        public interface InterfaceA { }
        public interface InterfaceB { }
    
        public class SomeBaseClass
        {
    
        }
    }
