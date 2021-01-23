    public class MyObject
    {
        public event EventHandler<MyEventArgs> OnFire;
        public void Fire()
        {
            if( OnFire != null )
            {
                //var e = new MyEventArgs { X=2 };
                var e = new MyEventArgsNew { X = 3, Y = 4 };
                OnFire( this, e );
            }
        }
    }
    public class MyEventArgs : EventArgs
    {
        public int X { get; set; }
    }
    public class MyEventArgsNew : MyEventArgs
    {
        public int Y { get; set; }
    }
    static void Main( string[] args )
    {
            var obj = new MyObject();
            obj.OnFire += new EventHandler<MyEventArgs>( obj_OnFire );
            obj.Fire();
            Console.ReadLine();
     }
     static void obj_OnFire( object sender, MyEventArgs e )
     {
            var e2 = (MyEventArgsNew)e;
            Console.WriteLine( e2.X );
            Console.WriteLine( e2.Y );
     }
