    using System;
    using System.Collections.Generic;
    using System.Reflection.Emit;
    public class SamplePoco
    {
        public int? Field1 { get; set; }
        public string Field2 { get; set; }
        // lots and lots more properties here
    }
    static class Program
    {
        static void Main()
        {
            var obj1 = new SamplePoco { Field1 = 123 };
            var obj2 = new SamplePoco { Field2 = "abc" };
            var merged = Merger.Merge(obj1, obj2);
            Console.WriteLine(merged.Field1);
            Console.WriteLine(merged.Field2);
        }
    }
    static class Merger
    {
        public static T Merge<T>(params T[] sources) where T : class, new()
        {
            var merge = MergerImpl<T>.merge;
            var obj = new T();
            for (int i = 0; i < sources.Length; i++) merge(sources[i], obj);
            return obj;
        }
        static class MergerImpl<T> where T : class, new()
        {
            internal static readonly Action<T, T> merge;
            static MergerImpl()
            {
                var method = new DynamicMethod("Merge", null, new[] { typeof(T), typeof(T) }, typeof(T));
                var il = method.GetILGenerator();
                Dictionary<Type, LocalBuilder> locals = new Dictionary<Type, LocalBuilder>();
                foreach (var prop in typeof(T).GetProperties())
                {
                    var propType = prop.PropertyType;
                    if (propType.IsValueType && Nullable.GetUnderlyingType(propType) == null)
                    {
                        continue; // int, instead of int? etc - skip
                    }
                    il.Emit(OpCodes.Ldarg_1); // [target]
                    il.Emit(OpCodes.Ldarg_0); // [target][source]
                    il.EmitCall(OpCodes.Callvirt, prop.GetGetMethod(), null); // [target][value]
                    il.Emit(OpCodes.Dup); // [target][value][value]
                    Label nonNull = il.DefineLabel(), end = il.DefineLabel();
                    if (propType.IsValueType)
                    { // int? etc - Nullable<T> - hit .Value
                        LocalBuilder local;
                        if (!locals.TryGetValue(propType, out local))
                        {
                            local = il.DeclareLocal(propType);
                            locals.Add(propType, local);
                        }
                        // need a ref to use it for the static-call
                        il.Emit(OpCodes.Stloc, local); // [target][value]
                        il.Emit(OpCodes.Ldloca, local); // [target][value][value*]
                        var hasValue = propType.GetProperty("HasValue").GetGetMethod();
                        il.EmitCall(OpCodes.Call, hasValue, null); // [target][value][value.HasValue]
                    }
                    il.Emit(OpCodes.Brtrue_S, nonNull); // [target][value]
                    il.Emit(OpCodes.Pop); // [target]
                    il.Emit(OpCodes.Pop); // nix
                    il.Emit(OpCodes.Br_S, end); // nix
                    il.MarkLabel(nonNull); // (incoming) [target][value]
                    il.EmitCall(OpCodes.Callvirt, prop.GetSetMethod(), null); // nix
                    il.MarkLabel(end); // (incoming) nix
                }
                il.Emit(OpCodes.Ret);
                merge = (Action<T, T>)method.CreateDelegate(typeof(Action<T, T>));
            }
        }
    }
