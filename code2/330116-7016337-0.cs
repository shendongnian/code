    using System;
    using System.Linq;
    using System.Reflection;
    public static object[] RetrieveInstancesOfPublicStaticPropertysOfTypeOnType(Type typeToUse) {
         var instances = new List<object>();
 
         var propsOfSameReturnTypeAs = from prop in typeToUse.GetProperties(BindingFlags.Public | BindingFlags.Static)
                                           where prop.PropertyType == typeToUse
                                           select prop;
 
         foreach (PropertyInfo props in propsOfSameReturnTypeAs) {
                 object invokeResult = typeToUse.InvokeMember(
                          props.Name, 
                          BindingFlags.GetProperty, 
                          null,
                          typeToUse, 
                          new object[] { }
                 );
 
                 if (invokeResult != null) {
                          instances.Add(invokeResult);
                 }
         }
 
         return instances.ToArray();
    }
