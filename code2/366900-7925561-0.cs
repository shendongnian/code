    public interface IData
    {
        string getData();
    }
    public class ROAD : IData
    {
        public string getData()
        {
            return "Marlton Road";
        }
    }
    public class PATH : IData
    {
        public string getData()
        {
            return "Tagore Path";
        }
    }
    public IData FETCH(bool flag)
    {
        if (flag)
        {
            ROAD obj = new ROAD();
            return obj;
        }
        else
        {
            PATH obj = new PATH();
            return obj;
        }
    }
