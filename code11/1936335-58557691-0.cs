            string gendercode = txtGenderNo.Text;
            using (var dbcontext = new Entities())
            {
                var something = Convert.ToInt32(gendercode);
                var GenderName = dbcontext
                         .Genders
                         .Where(u => u.Code == something)
                         .Select(u => u.GenderType)
                         .SingleOrDefault();
                txtGenderName.Text = GenderName;
            }
