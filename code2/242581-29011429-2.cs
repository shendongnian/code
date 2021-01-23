    private void backgroundWorker1_DoWork (object sender, DoWorkEventArgs e)
    {
            MyPerson person = e.Argument as MyPerson
            string firstname = person.FirstName;
            string lastname = person.LastName;
            int zipcode = person.ZipCode;                                 
    }
