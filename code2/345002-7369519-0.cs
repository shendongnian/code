    public class Message<T>
    {
         public object Sender { get; set; }
         public object Receiver { get; set; }
         public T ExtraInfo { get; set; }
    }
    
    public static void Main()
    {
         Message<double> doubleMessage = new Message<double>() { ExtraInfo = 4.0d };
         Message<string> stringMessage = new Message<string>() { ExtraInfo = "Hello World" };
    }
