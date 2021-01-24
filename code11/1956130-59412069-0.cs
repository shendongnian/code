    public class ABase
    {
        public int data { get; set; }
    }
    
    public class A1 : ABase {
        ... implementation that presumably sets data
    }
    
    public class A2 : ABase {
        ... implementation that presumably sets data
    }
    
    var example = GetData<ABase>();
    
    public void GetData<T>() where T : ABase {
       // Do something with T which can be A1 or A2 but supports GetData
    }
