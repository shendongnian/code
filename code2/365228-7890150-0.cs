    class RequestDetail{
        public void CreateMethod(RequestDetails reqD){ 
            //do what you need
            AbstCreateMethod(reqD);
        }
        public abstract void AbstCreateMethod(RequestDetails reqD);
    }
    class ClassA : RequestDetails{
        public void AbstCreateMethod(RequestDetails reqD){
            //do classA things  
        }
    }
    class ClassB : RequestDetails{
        public void AbstCreateMethod(RequestDetails reqD){
            //do classB things  
        }
    }
