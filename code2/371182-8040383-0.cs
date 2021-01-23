    var query = from t in lawDataContext.tblDocs.ToList()
                join x in xmlDataSet.Tables["Document"].AsEnumerable()
                    on t.SourceFile equals (x.Field<string>("xmlLink"))
                    into outer
                from o in outer.DefaultIfEmpty()
                select new
                {
                    lawID = t.ID,
                    xmlID = o == null ? 0 : o.Field<int>("id")
                }; 
