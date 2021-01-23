            DataClasses1DataContext db = new DataClasses1DataContext();
            var queryresults = from a in db.Authors                                          
                        join ba in db.Title_Authors                           
                        on a.Au_ID equals ba.Au_ID into idAuthor
                        from c in idAuthor
                        join t in db.Titles  
                        on c.ISBN equals t.ISBN 
                        select new { Author = a.Author1,Title= t.Title1 };
            foreach (var item in queryresults)
            {
                MessageBox.Show(item.Author);
                MessageBox.Show(item.Title);
                return;
            }
