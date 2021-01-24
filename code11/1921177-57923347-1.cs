    string commandText = "INSERT INTO dbo.student (FirstName, LastName, FatherName, Email, DateBirth,DateReg, Adress, Gender, Specialization, Country, Province,City) " +
                         "SELECT @FirstName,@LastName, @Fathername, @Email, @DateBirth, @DateReg, @Address, @Gender, s.specialization_id, c.country_id, p.province_id, cy.city_id " +
                         "FROM (SELECT specialization_id FROM dbo.specialization WHERE SpecializationName = @Specialization) s " +
                         "CROSS APPLY (select country_id from country where CountryName = @Country) c " +
                         "CROSS APPLY (select province_id from province where ProvinceName = @Province) p " +
                         "CROSS APPLY (select city_id from city where CityName = @City) cy;";
    
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand(commandText, connection);
        command.Parameters.Add(@FirstName, SqlDbType.VarChar,50).Value = this.txt_fname.Text;
        command.Parameters.Add(@LastName, SqlDbType.VarChar,50).Value = this.txt_lname.Text;
        command.Parameters.Add(@Fathername, SqlDbType.VarChar,50).Value = this.txt_fathername.Text;
        command.Parameters.Add(@Email, SqlDbType.VarChar,50).Value = this.txt_email.Text;
        command.Parameters.Add(@DateBirth, SqlDbType.Date).Value = this.date_birth.Text; //Shouldn't this be a date picker object?
        command.Parameters.Add(@DateReg, SqlDbType.Date).Value = this.date_reg.Text; //Shouldn't this be a date picker object?
        command.Parameters.Add(@Address, SqlDbType.VarChar,200).Value = this.txt_adress.Text; //It's spelt Address (2 d's)
        command.Parameters.Add(@Gender, SqlDbType.VarChar,10).Value = this.Gender; //Why did this not have the Text property?
        command.Parameters.Add(@Specialization, SqlDbType.VarChar,50).Value = this.specialization.Text;
        command.Parameters.Add(@CountryName, SqlDbType.VarChar,50).Value = this.comboBox2.Text; //You should name this combo box
        command.Parameters.Add(@Province, SqlDbType.VarChar,50).Value = this.comboBox4.Text; //You should name this combo box
        command.Parameters.Add(@City, SqlDbType.VarChar,50).Value = this.comboBox3.Text;//You should name this combo box
    }
