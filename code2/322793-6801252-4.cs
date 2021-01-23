    public abstract class UserDataManager : IUserDataManager
    {
        private readonly string filename;
    
        protected UserDataManager(string filename)
        {
            this.filename = filename;
        }
    
        public void SaveFile()
        {
            Console.WriteLine("File saved as: " + filename);
        }
    
        public void DeleteFile()
        {
            Console.WriteLine("File deleted: " + filename);
        }
    
        public abstract void Validate();
    }
    
    public class AccessUserDataManager : UserDataManager
    {
        public AccessUserDataManager(string filename) : base(filename) { }
    
        public override void Validate()
        {
            Console.WriteLine("Access validated");
        }
    }
    
    public class ExcellUserDataManager : UserDataManager
    {
        public ExcellUserDataManager(string filename) : base(filename) { }
    
        public override void Validate()
        {
            Console.WriteLine("Excel validated");
        }
    }
