    public interface IDoStuff
    {
        void Foo();
    }
    public class Wrapper(): DynamicObject
    {
        public static T Wrap<T>(T obj)
        {
            //you should probably check if T is an interface here.
            return Impromptu.ActLike<T>(new Wrapper(obj));
        }
        public override bool TryInvokeMember (InvokeMemberBinder binder, object[] args, out object result)
        {
            //do stuff
        }
    }
    IDoStuff wrappedDoStuff = Wrapper.Wrap(doStuff);
