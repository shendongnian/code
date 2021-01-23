        Patient patient = new Patient();
        Console.WriteLine(patient.Id); // will NOT be filled in
        Db.Patients.Add(patient);
        Db.SubmitChanges(); // SaveChanges in EF
        Console.WriteLine(patient.Id); // will be filled in
