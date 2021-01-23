var test1 = from t in test.Test
            select new MyOwnClass { 
                                   Name = t.Name, 
                                   Params = (from p in test.Params
                                             join p1 in test.Param on p.Params_Id equals p1.ParamsId
                                             where p.Test_Id == t.Test_Id
                                             select new Param {
                                                               Name = p1.Name,
                                                               Enabled = p1.Enabled
                                                              }).ToList()
                                  };
