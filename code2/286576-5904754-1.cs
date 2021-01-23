    abstract class Parent<T> where T : Parent<T> {
        virtual string ToXml()
        {
            XmlSerializer xml = XmlSerializer( typeof (T) );
            ...
            return xmlString;
        }
    
        virtual void FromXml(string rawXml)
        {
            //either memberwise copy or throw exception if wrong type
            ...
        }
    }
    
    sealed class Child1 : Parent<Child1>
    {
        [XmlElement("Prop1")] 
        public Property1 { get; set; }
    
        public Child1() { }
    }
    
    sealed class Child2 : Parent<Child1>
    {
        [XmlElement("Prop2")]
        public Property1 { get; set; }
    
        public Child2() { }
    }
    
    static void main()
    {
        string flatChild1 = new Child1().ToXml();
        string flatChild2 = new Child2().ToXml();
    
        // some time goes by
        ...
    
        Child1 one = new Child1();
        Child2 two = new Child2();
    
        one.FromXml(flatChild1); //must be "child one" string or exception
        two.FromXml(flatChild2);
        
        //one.FromXml(flatChild2); !! invalid
    
        /*
          what i want is some sort of factory...
          sealed class MyFactory<T>
          {
             static T MyFactory.FromXml(string xmlObject);
          }
        */
        Child1 obj1 = MyFactory<Child1>.FromXml(flatChild1);
        Child2 obj2 = MyFactory<Child2>.FromXml(flatChild2);
    
        Assert.IsInstanceOfType(obj1, Child1.GetType());
        Assert.IsInstanceOfType(obj2, Child2.GetType());
    }
