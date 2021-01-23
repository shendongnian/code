    public abstract class SafeNativeMethod
    {
        private readonly string libraryName;
        private readonly string methodName;
        private bool resolved;
        private bool exists;
        protected SafeNativeMethod(string libraryName, string methodName)
        {
            this.libraryName = libraryName;
            this.methodName = methodName;
        }
        protected bool CanInvoke
        {
            get
            {
                if (!this.resolved)
                {
                    this.exists = Resolve();
                    this.resolved = true;
                }
                return this.exists;	
            }            
        }
    
        private bool Resolve()
        {
            return NativeMethodResolver.MethodExists(this.libraryName, this.methodName);
        }
    }
