    // http://stackoverflow.com/questions/1273589/dynamic-object-property-populator-without-reflection
    namespace Test
    {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Reflection;
    using System.Reflection.Emit;
    public class ProductTest
    {
        public string ProductGuid { get; set; }
        public string ProductName { get; set; }
    }
    /// <summary>
    /// Summary description for ProductMapper
    /// </summary>
    public class ProductMapper
    {
        public ProductMapper()
        {
            DoTheMagic();
        }
        public ICollection<object> DoTheMagic()
        {
            Dictionary<string, object> product = new Dictionary<string, object>();
            product["ProductGuid"] = "Product Id";
            product["ProductName"] = "Product Name";
            Populator<ProductTest> builder = Populator<ProductTest>.CreateBuilder(product);
            ProductTest obj = builder.Build(product);
            return null;
        }
    }
    public class Populator<T>
    {
        private delegate T Load(Dictionary<string, object> properties);
        private Load _handler;
        private Populator() { }
        public T Build(Dictionary<string, object> properties)
        {
            T obj = default(T);
            try
            {
                obj = _handler(properties); // JIT Compiler encountered an internal limitation.
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
            return obj;
        }
        public static Populator<T> CreateBuilder(Dictionary<string, object> properties)
        {
            //private static readonly MethodInfo getValueMethod = typeof(IDataRecord).GetMethod("get_Item", new [] { typeof(int) });
            //private static readonly MethodInfo isDBNullMethod = typeof(IDataRecord).GetMethod("IsDBNull", new [] { typeof(int) });
            Populator<T> dynamicBuilder = new Populator<T>();
            DynamicMethod method = new DynamicMethod("Create", typeof(T), new[] { typeof(Dictionary<string, object>) }, typeof(T), true);
            ILGenerator generator = method.GetILGenerator();
            
            LocalBuilder result = generator.DeclareLocal(typeof(T));
            generator.Emit(OpCodes.Newobj, typeof(T).GetConstructor(Type.EmptyTypes));
            generator.Emit(OpCodes.Stloc, result);
            
            int i = 0;
            foreach (var property in properties)
            {
                PropertyInfo propertyInfo = typeof(T).GetProperty(property.Key, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase | BindingFlags.FlattenHierarchy | BindingFlags.Default);
                Label endIfLabel = generator.DefineLabel();
                if (propertyInfo != null && propertyInfo.GetSetMethod() != null)
                {
                    generator.Emit(OpCodes.Ldarg_0);
                    generator.Emit(OpCodes.Ldc_I4, i);
                    //generator.Emit(OpCodes.Callvirt, isDBNullMethod);
                    generator.Emit(OpCodes.Brtrue, endIfLabel);
                    generator.Emit(OpCodes.Ldloc, result);
                    generator.Emit(OpCodes.Ldarg_0);
                    generator.Emit(OpCodes.Ldc_I4, i);
                    //generator.Emit(OpCodes.Callvirt, getValueMethod);
                    generator.Emit(OpCodes.Unbox_Any, property.Value.GetType());
                    generator.Emit(OpCodes.Callvirt, propertyInfo.GetSetMethod());
                    generator.MarkLabel(endIfLabel);
                }
                i++;
            }
            generator.Emit(OpCodes.Ldloc, result);
            generator.Emit(OpCodes.Ret);
            dynamicBuilder._handler = (Load)method.CreateDelegate(typeof(Load));
            return dynamicBuilder;
        }
    }
    }
