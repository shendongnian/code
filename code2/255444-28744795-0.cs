    private void selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            facultyData row = (facultyData)facultyDataGrid.SelectedItem;
            facultyID_Textbox.Text = row.facultyID;
            lastName_TextBox.Text = row.lastName;
            firstName_TextBox.Text = row.firstName;
            middleName_TextBox.Text = row.middleName;
            age_TextBox.Text = row.age.ToString();
        }
       
    }
    class facultyData
    {
        public ObjectId _id { get; set; }
        public string facultyID { get; set; }
        public string acadYear { get; set; }
        public string program { get; set; }   
    }
