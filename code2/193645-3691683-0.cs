    public sealed class Settings : IUserStettings, IOSettings
    {
        static readonly Settings instance = new Settings();
        static Settings(){ }
        Settings(){ }
        public static Settings Instance
        {
            get { return instance; }
        }
        
        public string UserName
        {
            get { throw new NotImplementedException(); }
        }
        // ---etc...
         public string filename
        {
            get { throw new NotImplementedException(); }
        }
        //-- interface implementation
    }
    public interface IOSettings
    {
        public string disk {get;}
        public string path { get; }
        public string filename { get; }
    }
    public interface IUserStettings
    {
        public string UserName { get; }
        public string Password { get; }
    }
