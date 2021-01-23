    var mylist = (from inlst in db.Progs
                 where inlst.ProgID == PGID
                 select new Prog 
                 {
                    Date = inlst.Date1,
                    Name = inlst.Reps1,
                     // ..
                 }
