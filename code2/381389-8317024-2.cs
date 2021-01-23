    public class ConferenceAttendeeNameSearch : ISpecification<Conference>
    {
        public Expression<Func<Conference, bool>> IsSatisfied()
        {
            return a => a.People.Any(p => p.FirstName.Equals("David"));
        }
    }
