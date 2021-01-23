    class ComponentExecutor
    {
        public void Do()
        {
            using (var tc = (TestComponent)
                    FormatterServices.GetUninitializedObject(typeof(TestComponent)))
            {
                // call the ctor manually
                typeof(TestComponent).GetConstructor(Type.EmptyTypes).Invoke(tc, null);
                // maybe we can skip this since we are `using`
                GC.ReRegisterForFinalize(tc); 
                tc.Do();
            }
        }
    }
