public Patients GetPatientsbyMedicalNumber(int medicalNumber)
        {
            Patients patient = db.Patients.Where(e => e.medicalNumber == medicalNumber).FirstOrDefault();
            if (patients == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return patient;
        }
Can you specify the problem? are getting patients with your cousult before the return? or your metod doesent return a Patient object ?
