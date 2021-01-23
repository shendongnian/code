using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using static YourNamespace.DynamicTypeBuilderTest;
namespace YourNamespace
{
    /// This class builds Dynamic Anonymous Classes
    public class DynamicTypeBuilderTest
    {    
        ///   
        /// Create instance based on any Source class as example based on PersonalData
        ///
        public static object CreateAnonymousDynamicInstance(PersonalData personalData, Type dynamicType, List<ClassDescriptorKeyValue> classDescriptionList)
        {
            var obj = Activator.CreateInstance(dynamicType);
            var propInfos = dynamicType.GetProperties();
            classDescriptionList.ForEach(x => SetValueToProperty(obj, propInfos, personalData, x));
            return obj;
        }
        private static void SetValueToProperty(object obj, PropertyInfo[] propInfos, PersonalData aisMessage, ClassDescriptorKeyValue description)
        {
            propInfos.SingleOrDefault(x => x.Name == description.Name)?.SetValue(obj, description.ValueGetter(aisMessage), null);
        }
        public static dynamic CreateAnonymousDynamicType(string entityName, List<ClassDescriptorKeyValue> classDescriptionList)
        {
            AssemblyName asmName = new AssemblyName();
            asmName.Name = $"{entityName}Assembly";
            AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.RunAndCollect);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule($"{asmName.Name}Module");
            TypeBuilder typeBuilder = moduleBuilder.DefineType($"{entityName}Dynamic", TypeAttributes.Public);
            classDescriptionList.ForEach(x => CreateDynamicProperty(typeBuilder, x));
            return typeBuilder.CreateTypeInfo().AsType();
        }
        private static void CreateDynamicProperty(TypeBuilder typeBuilder, ClassDescriptorKeyValue description)
        {
            CreateDynamicProperty(typeBuilder, description.Name, description.Type);
        }
        ///
        ///Creation Dynamic property (from MSDN) with some Magic
        ///
        public static void CreateDynamicProperty(TypeBuilder typeBuilder, string name, Type propType)
        {
            FieldBuilder fieldBuider = typeBuilder.DefineField($"{name.ToLower()}Field",
                                                            propType,
                                                            FieldAttributes.Private);
            PropertyBuilder propertyBuilder = typeBuilder.DefineProperty(name,
                                                             PropertyAttributes.HasDefault,
                                                             propType,
                                                             null);
            MethodAttributes getSetAttr =
                MethodAttributes.Public | MethodAttributes.SpecialName |
                    MethodAttributes.HideBySig;
            MethodBuilder methodGetBuilder =
                typeBuilder.DefineMethod($"get_{name}",
                                           getSetAttr,
                                           propType,
                                           Type.EmptyTypes);
            ILGenerator methodGetIL = methodGetBuilder.GetILGenerator();
            methodGetIL.Emit(OpCodes.Ldarg_0);
            methodGetIL.Emit(OpCodes.Ldfld, fieldBuider);
            methodGetIL.Emit(OpCodes.Ret);
            MethodBuilder methodSetBuilder =
                typeBuilder.DefineMethod($"set_{name}",
                                           getSetAttr,
                                           null,
                                           new Type[] { propType });
            ILGenerator methodSetIL = methodSetBuilder.GetILGenerator();
            methodSetIL.Emit(OpCodes.Ldarg_0);
            methodSetIL.Emit(OpCodes.Ldarg_1);
            methodSetIL.Emit(OpCodes.Stfld, fieldBuider);
            methodSetIL.Emit(OpCodes.Ret);
            propertyBuilder.SetGetMethod(methodGetBuilder);
            propertyBuilder.SetSetMethod(methodSetBuilder);
        }
        public class ClassDescriptorKeyValue
        {
            public ClassDescriptorKeyValue(string name, Type type, Func<PersonalData, object> valueGetter)
            {
                Name = name;
                ValueGetter = valueGetter;
                Type = type;
            }
            public string Name;
            public Type Type;
            public Func<PersonalData, object> ValueGetter;
        }
        ///
        ///Your Custom class description based on any source class for example
        /// PersonalData
        public static IEnumerable<ClassDescriptorKeyValue> GetAnonymousClassDescription(bool includeAddress, bool includeFacebook)
        {
            yield return new ClassDescriptorKeyValue("Id", typeof(string), x => x.Id);
            yield return new ClassDescriptorKeyValue("Name", typeof(string), x => x.FirstName);
            yield return new ClassDescriptorKeyValue("Surname", typeof(string), x => x.LastName);
            yield return new ClassDescriptorKeyValue("Country", typeof(string), x => x.Country);
            yield return new ClassDescriptorKeyValue("Age", typeof(int?), x => x.Age);
            yield return new ClassDescriptorKeyValue("IsChild", typeof(bool), x => x.Age < 21);
            if (includeAddress)
                yield return new ClassDescriptorKeyValue("Address", typeof(string), x => x?.Contacts["Address"]);
            if (includeFacebook)
                yield return new ClassDescriptorKeyValue("Facebook", typeof(string), x => x?.Contacts["Facebook"]);
        }
        ///
        ///Source Data Class for example
        /// of cause you can use any other class
        public class PersonalData
        { 
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Country { get; set; }
            public int Age { get; set; }
            public Dictionary<string, string> Contacts { get; set; }
        }
    }
}
It is also very simple to use DynamicTypeBuilder, you just need put few lines like this:
    public class ExampleOfUse
    {
        private readonly bool includeAddress;
        private readonly bool includeFacebook;
        private readonly dynamic dynamicType;
        private readonly List<ClassDescriptorKeyValue> classDiscriptionList;
        public ExampleOfUse(bool includeAddress = false, bool includeFacebook = false)
        {
            this.includeAddress = includeAddress;
            this.includeFacebook = includeFacebook;
            this.classDiscriptionList = DynamicTypeBuilderTest.GetAnonymousClassDescription(includeAddress, includeFacebook).ToList();
            this.dynamicType = DynamicTypeBuilderTest.CreateAnonymousDynamicType("VeryPrivateData", this.classDiscriptionList);
        }
        public object Map(PersonalData privateInfo)
        {
            object dynamicObject = DynamicTypeBuilderTest.CreateAnonymousDynamicInstance(privateInfo, this.dynamicType, classDiscriptionList);
            return dynamicObject;
        }
    }
I hope that this code snippet help somebody =) Enjoy!
