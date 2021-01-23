    public class MockMilestoneService : IMilestoneService
    {
        public DatabaseCollection_Result<Milestone> GetMilestones()
        {
            DatabaseCollection_Result<Milestone> mileStones = new DatabaseCollection_Result<Milestone>();
            Milestone milestone1 = new Milestone();
            milestone1.Name = "New";
            Milestone milestone2 = new Milestone();
            milestone2.Name = "Assessment";
            mileStones.Results.Add(milestone1);
            mileStones.Results.Add(milestone2);
            return mileStones;
        }
    } 
