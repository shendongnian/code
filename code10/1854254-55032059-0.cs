    using (var db = new COMP1690Entities())
        {
            Driver d = db.Drivers.Where((dr) => dr.Id == val.Id).Include("DriverQualifications.Qualification").FirstOrDefault();
            d.DriverQualifications.Clear();
            foreach (DriverQualification q in val.DriverQualifications)
            {
                q.Fk_Qualifications_Id = q.Qualification.Id;
                q.Qualification = null;
                d.DriverQualifications.Add(q);
            }
            d.Phone_Number = val.Phone_Number;
            db.SaveChanges();
        }
