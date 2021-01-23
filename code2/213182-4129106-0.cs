    List<Form1> forms = new List<Form1>();
    string analyte;
    for(int i = 0; i < cbAnalytes.Items.Count; ++i)
    {
        cbAnalytes.SelectedIndex = i;
        analyte = cbAnalytes.Text;
        // Process the object depending on the type
        Form1 aform = new Form1(dateStart.Value.ToShortDateString(), dateEnd.Value.ToShortDateString(), cbQCValues.Text, analyte, cbInstruments.Text);
        aform.Show();
        forms.Add(aform);
    }
