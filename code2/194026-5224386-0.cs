    public class SubjectDTO: IEquatable<SubjectDTO>
    {
        public string Id;
        public bool Equals(SubjectDTO other)
        {
            return Object.Equals(Id, other.Id);
        }
        public override int GetHashCode()
        {
            return Id == null ? 1 : Id.GetHashCode();
        }
    }
