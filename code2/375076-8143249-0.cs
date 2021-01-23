        private bool hashCodeComputed;
        private int hashCode;
        public override int GetHashCode()
        {
            if(!this.hashCodeComputed)
            {
                if (Equals(Id, Guid.Empty))
                {
                    this.hashCode = base.GetHashCode();
                }
                else
                {
                    this.hashCode = Id.GetHashCode();
                }
                this.hashCodeComputed = true;
            }
            return this.hashCode;
        }
