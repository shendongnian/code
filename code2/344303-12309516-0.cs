My problem was a reflection method trying to make a deep copy between two classes because of a complex type.  I tried to define an explicit operator conversion, but it didn't seem to get called, so I figured out a way to get it by reflection.  Using some other research about calling static methods, I found this works for me when copying a complex type stored in pSource into a different type in property pDest.  the type in pDest has a conversion from pSource's type.
MethodInfo[] static_methods = pDest.PropertyType.GetMethods(System.Reflection.BindingFlags.Static | BindingFlags.Public);
if (static_methods != null)
{
    foreach (MethodInfo method in static_methods)
    {
        if(method.Name== "op_Explicit")                       // this is a constant
        {                                                     // for explicit operators
            ParameterInfo[] paramSet = method.GetParameters();
            if ((paramSet != null) && (paramSet.Length == 1)) 
            {
                if (paramSet[0].ParameterType == pSource.PropertyType) // match the types!
                {
                    pDest.SetValue(                          // Destination prop
                        dstVar,                              // Destination instance
                        method.Invoke(                       // converter method
                              null,                          // static has no 'this'
                              new object[] {                 // value to convert from
                                  pSource.GetValue(source, null) 
                              }                              // source property on
                                                             // source instance
                        )
                    ); // SetValue(...)
                }
            }
        }
    }
}
