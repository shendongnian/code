    class Class1{
        public decimal Value{get;}
    
        public Class1(decimal value){
            this.Value = value;
        }  
    }
    
    class Class2{
        public decimal Value{get; set;}
    
        public Class2(decimal value){
            this.Value = value;
        }
    }
    
    class Class3{
        public Class1 class1;
        public Class2 class2;
        public decimal Value { get; };
    
        public Class3(Class1 class1, Class2 class2){
            this.Value = class1.Value + class2.Value; 
        }   
    }
