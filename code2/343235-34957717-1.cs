        public override int GetHashCode()
        {
            int hash = 173;
            foreach (Byte b in Guid1.ToByteArray().Concat(Guid2.ToByteArray()))
            {
                hash = hash * 983 + b;
            }
            return hash;
        }
