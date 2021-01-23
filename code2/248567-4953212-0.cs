    protected void Show_Products(int item)
    {
        using (storeDataContext db = new storeDataContext())
        {
           var q = db.Items.OrderBy(x=> x.Name).Select(x => x);
            switch (item)
            {
                case 1:
                    var q = db.Items.OrderBy(x=> x.Name).Select(x => x);
                    break;
                case 2:
                    q = db.Items.OrderBy(x => x.MSRP).Select(x => x);
                    break;
                default:
                    break;
            }
            
            foreach(var n in q)
             {
               Do work
             }
           }
       }
