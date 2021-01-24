using System;
namespace Test
{
    public class ThirdPartyLibrary
    {
        public delegate void dEeventRaiser();
        public event dEeventRaiser OnReceiveCall;
        public string IncomingCall(int x)
        {
            
            if (x > 0 && OnReceiveCall != null)
            { OnReceiveCall(); return "Valid "+x.ToString(); }
            return "Invalid"+x.ToString();
        }
    }
    
    public class EventSubscription
    {
        public EventSubscription()
        {
            ThirdPartyLibrary a = new ThirdPartyLibrary();
            a.OnReceiveCall += HandleTheCall;
            var iAnswer = a.IncomingCall(24198724);
            Console.WriteLine("Call received from "+iAnswer);
        }
        
        public virtual void HandleTheCall()
        {
            Console.WriteLine("Default way I handle the call");
        }
    }
    public class Program : EventSubscription
    {
        public override void HandleTheCall()
        {
            Console.WriteLine("Override sucessful, new way to handle the call ");
        }
      
       static void Main(string [] args)
        {
          Program pb = new Program();  // Control goes EnventSubscription constructor as it is derived 
            Console.Read();
        }
       
    }
}
 **Output**:
[![enter image description here][2]][2]
  [1]: https://dotnetfiddle.net/xDIcMC
  [2]: https://i.stack.imgur.com/fJKKt.png
