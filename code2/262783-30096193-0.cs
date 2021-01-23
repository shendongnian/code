            var Owners = ctx.OwnerMasters;
            var Category = ctx.CategoryMasters;
            var Status = ctx.StatusMasters;
            var Tasks = ctx.TaskMasters;
            var xyz = from t in Tasks
                      join c in Category
                      on t.TaskCategory equals c.CategoryID
                      join s in Status
                      on t.TaskStatus equals s.StatusID
                      join o in Owners
                      on t.TaskOwner equals o.OwnerID
                      select new
                      {
                          t.TaskID,
                          t.TaskShortDescription,
                          c.CategoryName,
                          s.StatusName,
                          o.OwnerName
                      };
