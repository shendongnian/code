    //It is the generic datacontext
    public interface IDataContext
    {
        void Save();
    }
    //It is an implementation of the datacontext. You will
    //have one of this class per datacontext
    public class MyDataContext:IDataContext
    {
        private DataContext _datacontext;
        public MyDataContext(DataContext dataContext)
        {
            _datacontext = dataContext;
        }
        public void Save()
        {
            _datacontext.Save();
        }
    }
