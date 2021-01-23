    string patientId = "p99";
    int id;
    if (Int32.TryParse(patientId.Trim('p'), out id))
    {
        patientId = string.Format("p{0}{1}", id < 10 ? "0" : string.Empty, id);
        MessageBox.Show("Patient Id : " + patientId);
    }
    else
    {
       MessageBox.Show("Error while retrieving the patient id.");
    }
