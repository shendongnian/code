    static void Main(string[] args)
        {
            using(var db = new DataClasses1DataContext())
            {
                var query = db.Table1s.GroupBy(x => x.Name)
                    .Select(x => new
                                     {
                                         ID = x.Max(t => t.ID),
                                         Name = x.Max(t => t.Name),
                                         Date = x.Max(t => t.Date)
                                     });
                foreach (var n in query)
                {
                    Console.WriteLine(n.ID + " " + n.Name + " " + n.Date);
                }
                Console.WriteLine("");
                //Result:
                //4 charlie 12/9/2011
                //3 nero 11/11/2011
                var deleteQuery = db.Table1s.Where(x => !query.Select(t=> t.ID)
                                            .Contains(x.ID));
                db.Table1s.DeleteAllOnSubmit(deleteQuery);
                db.SubmitChanges();
                var testDeletion = db.Table1s;
                foreach (var n in testDeletion)
                {
                    Console.WriteLine(n.ID + " " + n.Name + " " + n.Date);   
                }
            }
        }
