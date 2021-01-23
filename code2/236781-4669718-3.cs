    public class TreatmentsRepository : GeneralRepository<Treatment, PatientsDataContext>
    {
        protected override Table<Treatment> GetTable(PatientsDataContext dc)
        {
            return dc.Treatments;
        }
    }
