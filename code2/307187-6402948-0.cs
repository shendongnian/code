    public class test<T> where T : class
    {
        public List<String> tt
        {
            get;
            set;
        }
    }
     ///////////////////////////
     test<List<String>> tt = new  test<List<String>>();
    if(tt.GetType().FullName.Contains(TypeOf(List<String>).FullName))
    {
       //do something
    }
    else
    {
        //do something else
    }
