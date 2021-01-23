    protected void MyFunction()
    {
        using(MyDataContext db = new MyDataContext())
        {
             // uncomment the following line for read only queries
             // db.ObjectTrackingEnabled = false;
             // implementation here
        }
    }
