        public interface IPartImportsSatisfiedNotification
        {
            void SomeMethod();
        }
    
        public abstract class MyClass : IDisposable, IPartImportsSatisfiedNotification
        {
            private string name;
            public MyClass(string name)
            {
                this.name = name;
            }
    
            public abstract void SomeMethod();
    
            public abstract void Dispose();
        }
    
        public class SubClass : MyClass
        {
            public SubClass(string someString) : base(someString)
            {
                
            }
    
            public override void SomeMethod()
            {
                throw new NotImplementedException();
            }
    
            public override void Dispose()
            {
                throw new NotImplementedException();
            }
        }
