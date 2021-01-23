    public class MyClass{
    
        private IMyDependency dependency;
        public MyClass(IMyDependency dependency){
            this.dependency = dependency;
        }
        public void DoSomething(){
            //invoke a method on the dependency
            this.dependency.DoWork();
        }
    
    }
