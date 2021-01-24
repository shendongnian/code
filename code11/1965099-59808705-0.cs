    public class BaseClass
    {
        public BaseClass()
        {
            className = "Base";
        }
        private void ReuseMethod()
        {
             commonLogic1();
             commonLogic2();
             commonLogic3();
             commonLogic4();
             commonLogic5();
             commonLogic6();
        }
    
        protected virtual void commonLogic2() { }
        protected virtual void commonLogic4() { }
        protected virtual void commonLogic6() { }
    }
    public class ClassA : BaseClass
    {
        public ClassA() : Base()
        {
            protected override void commonLogic2(){
               // DoSomethingSpecial
            }
        }
    }
