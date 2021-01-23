    public class Container
    {
        Dictionary<string, object> _objectContainer;
        public Container()
        {
            _objectContainer = new Dictionary<string, object>();
        }
        public void SetByName( string name, object obj )
        {
            if( !_objectContainer.ContainsKey( name ) )
            {
                _objectContainer.Add( name, obj );
            }
            else
            {
                _objectContainer[name] = obj;
            }
        }
        public object GetByName( string name )
        {
            return _objectContainer[name];
        }
    }
    public class ABuilder
    {
        public static A Build( Container container )
        {
            var a = new A();
            var obj1 = new object();
            var obj2 = new object();
            var obj3 = new object();
            container.SetByName( "obj1", obj1 );
            container.SetByName( "obj2", obj2 );
            container.SetByName( "obj3", obj3 );
            a.Obj1 = obj1;
            a.Obj2 = obj2;
            a.Obj3 = obj3;
            return a;
        }
    }
    class Program
    {
        static void Main( string[] args )
        {
            var container = new Container();
            var obj = ABuilder.Build( container );
            var obj1 = container.GetByName( "obj1" );
        } 
    }
