    public static List<MyOtherModel> GetPatientInfo(List<MyModel> patients)
    {
        using (..... MyDC = new... DataContext)
        {
            var OutputList = from f in MyDC.Table
                             where patients.Any(p => p.PatientID == f.PatientID)
                             select f;
        }
    }
