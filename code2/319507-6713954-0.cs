    var derived = new DerivedClass();
    Console.WriteLine(derived.GetBaseProperty("Prop"));    // displays "BaseProp"
    // ...
    public class BaseClass
    {
        public virtual string Prop { get { return "BaseProp"; } }
    }
    public class DerivedClass : BaseClass
    {
        public override string Prop { get { return "DerivedProp"; } }
        public object GetBaseProperty(string propName)
        {
            Type t = this.GetType();
            MethodInfo mi = t.BaseType.GetProperty(propName).GetGetMethod();
            var dm = new DynamicMethod("getBase_" + propName,
                                       typeof(object), new[] { t }, t);
            ILGenerator il = dm.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Call, mi);
            if (mi.ReturnType.IsValueType) il.Emit(OpCodes.Box, mi.ReturnType);
            il.Emit(OpCodes.Ret);
            var getBase = (Func<object>)dm.CreateDelegate(typeof(Func<object>));
            return getBase();
        }
    }
