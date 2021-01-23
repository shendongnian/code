    public class User: IEquatable<User>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Address { get; set; }
    
        public override int GetHashCode()
        {
            return Id ^ Id.GetHashCode(); // or whatever
        }
    
        public override bool Equals(object other)
        {
            return this.Equals(other as User);
        }
    
        public bool Equals(User other)
        {
            return (other != null &&
                    other.Id == this.Id &&
                    other.Username == this.Username &&
                    other.Address == this.Address );
        }
    }
