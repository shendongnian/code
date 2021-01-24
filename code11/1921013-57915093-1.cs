    String existingFileContents = File.ReadAllText( path );
    CompaniesFile json = JsonConvert.DeserializeObject<CompaniesFile>( existingFileContents );
    
    Company newCompany = new Company
    {
        CompanyName = textBox1.Text,
        IPO = Convert.ToDouble(textBox2.Text),
        Category = CategorycomboBox1.SelectedItem.ToString(),
        Description = textBox4.Text,
        StartDate = Convert.ToInt32(textBox5.Text)
    };
    json.Companies.Add( newCompany );
    String newFileContents = JsonConvert.Serialize( json );
    File.WriteAllText( newFileContents );
