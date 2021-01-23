    public class SomeBusinessLogicClass {
    
        private readonly IThirdLayer _repository;
        
        //constructor injection for the win!
        public SomeBusinessLogicClass(IThirdLayer repository) {
            _repository = repository;
        }
    
        public void SomeBusinessLogicMethod(SomeArgs arg) {
            //example use of repository
            _repository.SomeMethod(arg);
        }
    }
