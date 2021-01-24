        public abstract class A
        {
            protected abstract void SomeFunction();
        }
    
        public class B : A
        {
            protected override sealed void SomeFunction()
            {
                //do something
            }
        }
