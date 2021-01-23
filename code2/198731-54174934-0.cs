            /// <summary>
            /// Computes the size of the given managed type. Slow, but reliable. Does not give the same result as Marshal.SizeOf
            /// NOTE: this is not the same as what is the distance between these types in an array. That varies depending on alignment.
            /// </summary>
            public static int ComputeSizeOf(Type t)
            {
                // all this just to invoke one opcode with no arguments!
                var method = new DynamicMethod("ComputeSizeOfImpl", typeof(int), Type.EmptyTypes, typeof(Util), false);
                var gen = method.GetILGenerator();
                gen.Emit(OpCodes.Sizeof, t);
                gen.Emit(OpCodes.Ret);
                var func = (Func<int>)method.CreateDelegate(typeof(Func<int>));
                return func();
            }
