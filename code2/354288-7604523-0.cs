    public RefreshCamper(string firstName)
    {
        Camper person = new Camper(camp.txtNewFirstName.Text);
        camp.txtNewFirstName.Text = person.getName();
        c.testListBox.Items.Add(person.getName());
        campersFrame.Content = c;
        // ETC...
    }
