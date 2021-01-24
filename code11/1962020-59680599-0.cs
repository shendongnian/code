    public class MyPageBase<T> : WebViewPage<T>
        {
            //The exact same properties
            private DbContext db;
            public MyPageBase()
            {
                db = new MPContext();
            }
    
            public List<T> Fill()
            {
                return db.Set<T>().ToList();
            }
    
            public T FillBy(object id)
            {
                return db.Set<T>().Find(id);
            }
        }
