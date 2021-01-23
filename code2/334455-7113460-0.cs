        public override bool Equals(object obj)
        {
            if(obj is T) return Quote.Equals(obj);
            if (obj is ItemWrapper<T>) return Quote.Equals(((ItemWrapper<T>)obj).Quote);
            return this == obj;
        }
        public override int GetHashCode() { return Quote.GetHashCode(); }
        public override string ToString() { return Quote.ToString(); }
