C#
    public class SingleData<T> where T : SingleData<T>, new()
    {
        public static Lazy<T> val = new Lazy<T>(() => new T());
        public static IPlugin Instance { get { return val.Value; } }
        protected SingleData() { }
        public string Author { get; set; }
        public string Name { get; set; }
        public virtual void plugin_getUser(UserData user) { }
    }    
    // this class is also in the api dll file
    public class DllExport
    { 
        [DllExport]
        public static void plugin_getUser(UserData user) { return SingleData<Main>.Instance.plugin_getUser(user); }
     }
Usage,
C#
    public class Main : SingleData<Main>
    {
        public Main()
        {
           Author = "Hans";
           Name = "test plugin";
        }
        public override void plugin_getUser(UserData user)
        { 
           Console.WriteLine(user.OnlineTime);
        }    
    }
