    public class C
    {
        public List<object> mList;
        public void M()
        {
            List<object> list = mList;
            if (list != null)
            {
                list.Add(new object());
            }
        }
    }
