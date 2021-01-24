    var update = db.InfoStudents.Where(o => o.Id == Convert.ToInt32(TxtId.Text)).FirstOrDefault();
            if (update != null)
            {
                update.ImageStudent = addres;
            }
            else
            {
                MessageBox.Show("not ok");
            }
            db.SubmitChanges();
