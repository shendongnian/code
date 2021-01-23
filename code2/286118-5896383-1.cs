    public class YourBindingSource : BindingSource, ISupportInitialize
    {
        public void BeginInit()
        {
            Type baseType = base.GetType();
            InterfaceMapping interfaceMapping = baseType.GetInterfaceMap(typeof(ISupportInitialize));
            
            foreach(MethodInfo targetMethod in interfaceMapping.TargetMethods)
            {
                bool isBeginInitMethod = ...; // Could be determined by checking the name..
                if(isBeginInitMethod)
                {
                    targetMethod.Invoke(this, new object[0]);
                }
            }
        }
    }
