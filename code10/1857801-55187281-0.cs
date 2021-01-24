    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    public static class ShimHelper
    {
        public static void Replace<TOriginal, TTarget>()
        {
            var typeOfOriginal = typeof(TOriginal);
            Replace<TTarget>(typeOfOriginal);
        }
        public static void Replace<TTarget>(Type typeOfOriginal)
        {
            var targetMethods = GetStaticPublicMethods<TTarget>();
            foreach (var targetMethod in targetMethods)
            {
                var parameters = targetMethod.GetParameters().Select(x => x.ParameterType).ToArray();
                var originalMethod = typeOfOriginal.GetMethod(targetMethod.Name, parameters);
                if (originalMethod != null)
                {
                    SwapMethodBodies(originalMethod, targetMethod);
                }
                else
                {
                    Debug.WriteLine(
                        "*****************************************************************************************");
                    Debug.WriteLine($"Method not found - {targetMethod.Name}");
                    Debug.WriteLine(
                        "*****************************************************************************************");
                }
            }
        }
        
        private static List<MethodInfo> GetStaticPublicMethods<T>()
        {
            return typeof(T).GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Distinct().ToList();
        }
        private static void SwapMethodBodies(MethodInfo a, MethodInfo b)
        {
            RuntimeHelpers.PrepareMethod(a.MethodHandle);
            RuntimeHelpers.PrepareMethod(b.MethodHandle);
            unsafe
            {
                if (IntPtr.Size == 4)
                {
                    Replace32Bit(a, b);
                }
                else
                {
                    Replace64Bit(a, b);
                }
            }
        }
        private static unsafe void Replace64Bit(MethodInfo a, MethodInfo b)
        {
            var inj = (long*)b.MethodHandle.Value.ToPointer() + 1;
            var tar = (long*)a.MethodHandle.Value.ToPointer() + 1;
            *tar = *inj;
        }
        private static unsafe void Replace32Bit(MethodInfo a, MethodInfo b)
        {
            var inj = (int*)b.MethodHandle.Value.ToPointer() + 2;
            var tar = (int*)a.MethodHandle.Value.ToPointer() + 2;
            *tar = *inj;
        }
    }
