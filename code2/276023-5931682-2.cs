    internal class TestBaseClass
    {
        private static void BasePrivateStaticMethod() { }
        private void BasePrivateMethod() { }
        private void BasePrivateGenericMethod<T>() { }
        protected static void BaseProtectedStaticMethod() { }
        protected void BaseProtectedMethod() { }
        protected void BaseProtectedGenericMethod<T>() { }
        protected virtual void OverriddenProtectedMethod() { }
        protected virtual void OverriddenProtectedGenericMethod<T>() { }
        internal static void BaseInternalStaticMethod() { }
        internal void BaseInternalMethod() { }
        internal void BaseInternalGenericMethod<T>() { }
        internal virtual void OverriddenInternalMethod() { }
        internal virtual void OverriddenInternalGenericMethod<T>() { }
        public static void BasePublicStaticMethod() { }
        
        public void BasePublicMethod() { }
        public void BasePublicGenericMethod<T>() { }
        public virtual void OverriddenPublicMethod() { }
        public virtual void OverriddenPublicGenericMethod<T>() { }
    }
    internal class TestClass : TestBaseClass
    {
        public string Property
        {
            get { return null; }
        }
        private static void PrivateStaticMethod() { }
        private void PrivateMethod() { }
        private void PrivateGenericMethod<T>() { }
        protected static void ProtectedStaticMethod() { }
        protected void ProtectedMethod() { }
        protected static void ProtectedGenericMethod<T>() { }
        internal static void InternalGenericMethod<T>() { }
        internal void InternalMethod() { }
        internal static void InternalStaticMethod() { }
        public static void PublicStaticMethod() { }
        public void PublicMethod() { }
        public static void PublicGenericMethod<T>() { }
        internal override void OverriddenInternalMethod()
        {
            base.OverriddenInternalMethod();
        }
        protected override void OverriddenProtectedMethod()
        {
            base.OverriddenProtectedMethod();
        }
        public override void OverriddenPublicMethod()
        {
            base.OverriddenPublicMethod();
        }
    
        internal override void OverriddenInternalGenericMethod<T>()
        {
            base.OverriddenInternalGenericMethod<T>();
        }
        protected override void OverriddenProtectedGenericMethod<T>()
        {
            base.OverriddenProtectedGenericMethod<T>();
        }
        public override void OverriddenPublicGenericMethod<T>()
        {
            base.OverriddenPublicGenericMethod<T>();
        }
    }
