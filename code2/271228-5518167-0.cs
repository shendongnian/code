    public static List<MyOtherModel> GetPatientInfo(List<MyModel list>
    {
        using (..... MyDC = new... DataContext)
        {
            var result = from f in MyDC.Table
                         where list.Select(m => m.PatientID).Contains(f.PatientID)
                         select f;
            return result.ToList();
        }
    }
