        public abstract class MyClass : IDisposable, IPartImportsSatisfiedNotification
        {
            private string name;
            public MyClass(string name)
            {
                this.name = name;
            }
            public abstract void Dispose();
        }
