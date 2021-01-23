            IQueryable<DataModel.Object> query  = db.Object;
                
            If ((int)cmb_somthing.SelectedValue) > 0 {
                int ID  = (int)cmb_somthing.SelectedValue;
                query = query.Where(m=> m.ID = ID);
            }
            query = query.Where(m=> m.Date >= StartDate &&
                                    m.Date <= EndDate);
