        ArrayList arrGender = new ArrayList();
        arrGender.Add(new { id = 0, sex = "Male" });
        arrGender.Add(new { id = 1, sex = "Female" });
        cbGender.DataSource = arrGender;
        cbGender.DisplayMember = "sex";
        cbGender.ValueMember = "id";
