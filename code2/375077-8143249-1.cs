        private int? requestedHashCode;
        public override int GetHashCode()
        {
            if (!requestedHashCode.HasValue)
            {
                requestedHashCode = isTransient(this) 
                    ? base.GetHashCode() 
                    : this.Id.GetHashCode();
            }
            return requestedHashCode.Value;
        }
