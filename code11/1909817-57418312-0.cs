    [Serializable]  
    public class MyViewModel : Screen
    {
      public int n1 = 0;  
      public int n2 = 0;  
      public String str = null;  
    }
    
    MyViewModel obj = new MyViewModel();  
    obj.n1 = 1;  
    obj.n2 = 24;  
    obj.str = "Some String";  
    IFormatter formatter = new BinaryFormatter();  
    Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);  
    formatter.Serialize(stream, obj);  
    stream.Close();
    // Here's the proof.  
    Console.WriteLine("n1: {0}", obj.n1);  
    Console.WriteLine("n2: {0}", obj.n2);  
    Console.WriteLine("str: {0}", obj.str); 
 
