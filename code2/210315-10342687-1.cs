    class GenericLookupE : IEquatable<GenericLookupE>
    {
        public string	ID	{ get; set; }
        public bool		Equals( GenericLookupE other )
        {
            if ( this.ID == other.ID )		return true;
            return false;
        }
    }
