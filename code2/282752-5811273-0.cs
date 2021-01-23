    public class Patient
    {
        public int PatientID { get; set; }
        public string Name { get; set; }
    }
    static Patient getDetails()
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                var c = (from x in db.Patients.OrderByDescending(u => u.PatientID)
                         select new Patient()
                         {
                             PatientID = x.PatientID,
                             Name = x.Name
                         }).FirstOrDefault();
                return c;
            }
