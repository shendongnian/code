                    var query = (from c in db.Tbl_Model
							 join o in db.Tbl_ModelImg.GroupBy(m => m.Model_Id).Select(m 
                              => m.FirstOrDefault())
							  on c.Model_Id equals o.Model_Id 
							 join d in db.Tbl_SubCategory on c.SubCategory_Id equals d.Id
							 where c.SubCategory_Id == sId
							 select new showdata()
							 {
								 tm = c,
								 tmi = o,
								 tblsubcategory = d
								 
							 }).OrderByDescending(d => d.tm.Id).ToList();
