    public class ObjectB
    {
        ObjectC objC;
        public ObjectB()
        {
            objC = new ObjectC();
        }
        public event EventFiredEventHandler EventFired
        {
            add { this.objC.EventFired += value; }
            remove { this.objC.EventFired -= value; }
        }
    }
