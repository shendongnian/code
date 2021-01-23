    class ComponentExecutor
    {
        public void Do()
        {
            using (var tc = (TestComponent)
                    FormatterServices.GetUninitializedObject(typeof(TestComponent)))
            {
                // maybe we can skip this since we are `using`
                GC.ReRegisterForFinalize(tc); 
                tc.Do();
            }
        }
    }
