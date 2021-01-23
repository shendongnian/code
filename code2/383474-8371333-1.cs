                int IComparable<Post>.CompareTo(Post other)
                {
                    return id.Compare(other.id);
                }
                bool IEquatable<Post>.Equals(Post x)
                {
                    return id == y.id;
                }
           
         
                bool IEqualityComparer<Post>.Equals(Post x, Post y)
                {
                    return x.Equals(y.id);
                }
                int IEqualityComparer<Post>.GetHashCode(Post obj)
                {
                    return obj.id.GetHashCode(); 
                }
                int IComparer<Post>.Compare(Post x, Post y)
                {
                    return x.Compare(y);
                }
