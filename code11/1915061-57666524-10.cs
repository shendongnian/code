    public class ConcreteA {
        private ConcreteB B;
    
        public ConcreteA(ConcreteB B) {
            this.B = B;
        }
    
        public void Run() {
            ... //use ConcreteB  instance
        }    
    }
