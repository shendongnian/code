    abstract class MyAbstractClass{
    
        MyHelperClassBase myHelper;
    
        protected void foo() {
            myHelper = createHelper();
        }
        
        protected abstract MyHelperClassBase createHelper();
    }
    
    class MySubClass : MyAbstractClass{
        protected override MyHelperClassBase createHelper(){
            return new MyHelperSubClass();
        }
    }
    
    class MyOtherSubClass : MyAbstractClass{
        protected override MyHelperClassBase createHelper(){
            return new MyOtherHelperSubClass();
        }
    }
    
