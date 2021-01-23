    public class Foo()
    { 
        //Field
        private int _bar;
        //Property
        public int Bar
        {
            get { return _bar; }
            set { _bar = value; }  
            //value is an implicit parameter to the set acccessor.
            //When you perform an assignment to the property, the value you
            //assign is the value in "value"
        }
    }
