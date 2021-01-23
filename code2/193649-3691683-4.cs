    public sealed class Settings : IUserStettings, IOSettings
    {
        static readonly Settings instance = new Settings();
        static Settings(){ }
        Settings(){ }
        public static Settings Instance
        {
            get { return instance; }
        }
        //-- interface implementation
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
        string disk {get;}
        string path { get; }
        string filename { get; }
    }
    public interface IUserStettings
    {
        string UserName { get; }
        string Password { get; }
    }
