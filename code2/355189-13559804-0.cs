	public class HackedTypeEqualityComparer : EqualityComparer<Type> { 
		public override bool Equals(Type one, Type other){
			return ReferenceEquals(one,null) 
				? ReferenceEquals(other,null)
				: !ReferenceEquals(other,null) 
					&& ( (one is TypeDelegator || !(other is TypeDelegator)) 
						? one.Equals(other) 
						: other.Equals(one));
		}
		public override int GetHashCode(Type type){ return type.GetHashCode(); }
	}
