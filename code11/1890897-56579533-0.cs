using Client;
namespace Engine
{
    public class Engine1
    {
        public Engine1()
        {
            var myObject = new MyObject
            {
                SomeProperty = null
            };
            ClientAction.OpenForm(myObject);
        }
    }
    public class MyObject : IMyObject
    {
        public object SomeProperty { get; set; }
        public void DoSomething()
        {
            // do something
        }
    }
}
**Client**
namespace Client
{
    public class ClientAction
    {
        public ClientAction() { }
        public OpenForm(IMyObject myObject)
        {
            myObject.DoSomething();
            Form1.Open(myObject.SomeProperty);
        }
    }
    public interface IMyObject
    {
        object SomeProperty { get; set; }
        void DoSomething();
    }
}
