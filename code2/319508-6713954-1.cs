    var derived = new DerivedClass();
    Console.WriteLine(derived.GetBaseProperty("Prop"));    // displays "BaseProp"
    // ...
    public class BaseClass
    {
        public virtual string Prop { get; set;}
    }
    public class DerivedClass : BaseClass
    {
        public override string Prop { get; set;}
        public DerivedClass()
        {
            base.Prop = "BaseProp";
            this.Prop = "DerivedProp";
        }
        public object GetBaseProperty(string propName)
        {
            Type t = this.GetType();
            MethodInfo mi = t.BaseType.GetProperty(propName).GetGetMethod();
            var dm = new DynamicMethod("getBase_" + propName, typeof(object), new[] { typeof(object) }, t);
            ILGenerator il = dm.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Call, mi);
            if (mi.ReturnType.IsValueType) il.Emit(OpCodes.Box, mi.ReturnType);
            il.Emit(OpCodes.Ret);
            var getBase = (Func<object, object>)dm.CreateDelegate(typeof(Func<object, object>));
            return getBase(this);
        }
    }
