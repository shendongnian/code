    public ClassB : ITemp {
        protected ClassA classAInstance;
    
        public ClassB( ClassA obj ) {
            classAInstance = obj;
        }
    
        public void MyCustomMethod() {
            classAInstance.MyCustomMethod();
        }
    }
