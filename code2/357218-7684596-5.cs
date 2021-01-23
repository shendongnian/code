    public List<Patient> Patients; // Patient collection
    //Populate your listBox with these patient objects.
    
    private void textBox1_LostFocus(object sender, RoutedEventArgs e)
    {
         if (listBox1.SelectedItem == null) return;
         
         var patient = listBox1.SelectedItem as Patient; // Get the selected PObj;
         patient.Name = textBox1.Text; 
         Serialize(Patients); //Save the list to xml
    }
