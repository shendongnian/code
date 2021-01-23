     unsafe
            {
               // this seems to always be null
               GraphicsDevice parent = (GraphicsDevice)typeof(GraphicsDevice).GetField("_parent", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(oldDevice);
               IntPtr pInterface = new IntPtr(Pointer.Unbox(typeof(GraphicsDevice).GetField("pComPtr", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(oldDevice)));               
               ConstructorInfo ci = typeof(GraphicsDevice).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)[0];
               GraphicsDevice newDevice = (GraphicsDevice)ci.Invoke(new object[] { pInterface, parent });
            }
