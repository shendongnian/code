            string patientId = "p99";
            int id;
            if (Int32.TryParse(patientId.Trim('p'), out id))
            {
                MessageBox.Show("Patient Id : " + id);
            }
            else
            {
                MessageBox.Show("Error while retrieving the patient id.");
            }
