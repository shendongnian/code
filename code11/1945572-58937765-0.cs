        public abstract class AbstractClass
        {
            protected abstract void PrimitiveOperation();
            
            public void TemplateMethod()
            {
                // before common functionality
                PrimitiveOperation();
                // after common functionality
            }
        }
        class ConcreteClassA : AbstractClass
        {
            protected override void PrimitiveOperation()
            {
                // your A logic
            }
        }
        class ConcreteClassB : AbstractClass
        {
            protected override void PrimitiveOperation()
            {
                // your B logic
            }
        }
