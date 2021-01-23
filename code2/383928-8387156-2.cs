    public interface IDoStuff
    {
        void Foo();
    }
    
    public class Wrapper<T> : DynamicObject
    {
        private readonly T _wrappedObject;
        public static T1 Wrap<T1> (T1 obj) where T1 : class
        {
            if (!typeof (T1).IsInterface)
                throw new ArgumentException ("T1 must be an Interface");
            return new Wrapper<T1> (obj).ActLike<T1> ();
        }
        //you can make the contructor private so you are forced to use the Wrap method.
        private Wrapper (T obj)
        {
            _wrappedObject = obj;
        }
        public override bool TryInvokeMember (InvokeMemberBinder binder, object[] args, out object result)
        {
            try
            {
                //do stuff here
                //call _wrappedObject object
                result = _wrappedObject.GetType ().GetMethod (binder.Name).Invoke (_wrappedObject, args);
                return true;
            }
            catch
            {                
                result = null;
                return false;
            }
        }
    }
