    public void SomeMethod()
        {
            MyTable table= new MyTable();
            bool b=  MyMethod(table.Name, "Fred");
           if(b)
             //Do something
           else
             //Do something else
        }
        public bool MyMethod(MyTable a, object value)
        {
            using(var context= new MyDBEntities())
            {
                return context.MyTable.Where(i => a == value).Any();
            }
        }
