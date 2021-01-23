    public class MyDerivedMessage : MyMessage, IMsg
    { 
        public new void message() 
        { 
            Console.WriteLine("MyDerivedMessage"); 
        } 
    }
