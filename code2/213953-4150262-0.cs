    public class MyClass
    {
        public MyClass()
        {
            MyBlobProperty_Blob= new Blob();
        }
    
        public virtual byte[] MyBlobProperty
        {
            get { return MyBlobProperty_Blob.Bytes; }
        }
    
        protected virtual Blob MyBlobProperty_Blob { get; private set; }
    }
