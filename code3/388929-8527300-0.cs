    var db = DatabaseContext.FromContext().DatabaseName;
    var AllData = from A in db.TableA
                  from B in db.TableB
                  where A.ID == B.TableAID
                  select new {A,B};
    var Result = AllData.AsEnumerable().Select(dat=>new{A=dat.A.ToModel(),B=dat.B.ToModel()});
