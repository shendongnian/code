     using (dbTestDataContext db = new dbTestDataContext())
            {
                var query = (from r in db.Table1
                            where r.Code == getCode
                            select new
                            {
                                //Account Info
                                r.Name,
                                r.Num,
                                r.AcctNum,
                                r.CorpAcct, //Bool
    
    
                            }).FirstOrDefault();
    
                 if (query != null)
                 {
                    tbName.Text = query.Name;
                    tbNum.Text = query.Num;
                    //and so on
                    rbl.SelectedValue = query.SomeValue;
                 }
            };
