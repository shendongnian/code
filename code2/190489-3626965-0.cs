    public interface ISomething
    {
        void HelloWorld();
    }
    internal class OldParent : ISomething
    {
        public void HelloWorld(){ Console.WriteLine("Hello World!"); }
    }
    public class OldChild : ISomething
    {
        OldParent _oldParent = new OldParent();
        public void HelloWorld() { _oldParent.HelloWorld(); }
    }
