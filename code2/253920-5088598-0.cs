    public delegate void ErrorCollector(string errorDescription);
    public class MainControl
    {
        public void Execute()
        {
            new DoA(CollectErrors).DoStuff();
            new DoB(CollectErrors).DoStuff();
            //Display Errors encountered during processing in DoA and DoB
            foreach (string s in _errorList)
            {
                Console.WriteLine(s);
            }
        }
        public IList<string> ErrorList
        { get {return _errorList} }
        private void CollectErrors(string errorDescription)
        {
            _errorList.Add(errorDescription);    
        }
        private readonly IList<string> _errorList = new List<string>();
    }
    public class DoA
    {
        private readonly ErrorCollector _errorCollector;
        public DoA(ErrorCollector errorCollector)
        {
            _errorCollector = errorCollector;
        }
        public void DoStuff()
        {
            //Do something
            //Perhaps error occurs: 
            _errorCollector("ERROR IN DoA!!!");
        }
    }
    public class DoB
    {
        private readonly ErrorCollector _errorCollector;
        public DoB(ErrorCollector errorCollector)
        {
            _errorCollector = errorCollector;
        }
        public void DoStuff()
        {
            //Do something
            //Perhaps error occurs: 
            _errorCollector("ERROR IN DoB!!!");
        }
    }
