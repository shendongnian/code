    // Note: This method replaces methodToReplace with methodToInject
    // Note: methodToInject will still remain pointing to the same location
    public static unsafe MethodReplacementState Replace(this MethodInfo methodToReplace, MethodInfo methodToInject)
            {
    //#if DEBUG
                RuntimeHelpers.PrepareMethod(methodToReplace.MethodHandle);
                RuntimeHelpers.PrepareMethod(methodToInject.MethodHandle);
    //#endif
                MethodReplacementState state;
    
                IntPtr tar = methodToReplace.MethodHandle.Value;
                if (!methodToReplace.IsVirtual)
                    tar += 8;
                else
                {
                    var index = (int)(((*(long*)tar) >> 32) & 0xFF);
                    var classStart = *(IntPtr*)(methodToReplace.DeclaringType.TypeHandle.Value + (IntPtr.Size == 4 ? 40 : 64));
                    tar = classStart + IntPtr.Size * index;
                }
                var inj = methodToInject.MethodHandle.Value + 8;
    #if DEBUG
                tar = *(IntPtr*)tar + 1;
                inj = *(IntPtr*)inj + 1;
                state.Location = tar;
                state.OriginalValue = new IntPtr(*(int*)tar);
    
                *(int*)tar = *(int*)inj + (int)(long)inj - (int)(long)tar;
                return state;
    
    #else
                state.Location = tar;
                state.OriginalValue = *(IntPtr*)tar;
                * (IntPtr*)tar = *(IntPtr*)inj;
                return state;
    #endif
            }
        }
    
        public struct MethodReplacementState : IDisposable
        {
            internal IntPtr Location;
            internal IntPtr OriginalValue;
            public void Dispose()
            {
                this.Restore();
            }
    
            public unsafe void Restore()
            {
    #if DEBUG
                *(int*)Location = (int)OriginalValue;
    #else
                *(IntPtr*)Location = OriginalValue;
    #endif
            }
        }
