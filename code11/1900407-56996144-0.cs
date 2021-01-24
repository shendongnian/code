    [DataContract]
    public abstract class MyBase
    {
        [DataMember]
        public abstract int DoAdd { get; set; }
      
        public void MyOtherFunc()
        {
            Console.WriteLine("Done");
        }
    }
    [DataContract]
    public class MyWCF : MyBase
    {
        int a;
        [DataMember]
        public override int DoAdd
        {
            get { return a; }
            set { a = value; }
        }
    }
