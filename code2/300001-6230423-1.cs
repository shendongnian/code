    public class BookService
    {
        public IList<BookViewModel> GetBookViewModel()
        {
            var obj = new table1TableAdapter();  //Mysql Table Adapter
            var obj2 = new Table1TableAdapter(); // Sqlite Table Adapter
            var ds = new DataSet();
            ds.Tables.Add(obj.GetData());
            ds.Tables.Add(obj2.GetData());
            var tab1 = ds.Tables[0];
            var tab2 = ds.Tables[1];
            var query = from o in tab1.AsEnumerable()
                        join od in tab2.AsEnumerable()
                        on o.Field<string>("Name") equals od.Field<string>("Name")
                        select new BookViewModel
                        {
                            Name = o.Field<string>("Name"),
                            Rollno = od.Field<Int64>("rollno"),
                            Book = o.Field<string>("Book")
                        };
            return query.ToList();
        }
    }
