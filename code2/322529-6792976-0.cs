    public class Parent
    {
        public Parent()
        {
            PostConstructor();
        }
        protected virtual void PostConstructor()
        {
        }
    }
    public class Child : Parent
    {
        protected override void PostConstructor()
        {
            base.PostConstructor();
            /// do whatever initialization here that you require
        }
    }
    public class ChildWithoutOverride
    {
        /// not necessary to override PostConstructor 
    }
