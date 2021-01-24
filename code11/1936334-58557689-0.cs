    var genderCodeAsInt = Convert.ToInt32(gendercode);
    using (var dbcontext = new Entities())
    {
        var GenderName = dbcontext
                         .Genders
                         .Where(u => u.Code == genderCodeAsInt)
                         .Select(u => u.GenderType)
                         .SingleOrDefault();
                txtGenderName.Text = GenderName;
    }
