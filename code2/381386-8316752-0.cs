    public class ConferenceAttendeeNameSearch : ISpecification<Conference>
    {
        public Expression<Func<Conference, bool>> IsSatisfied()
        {
            return a => a.People.Where(p => p.FirstName.Equals("David"));
        }
    }
