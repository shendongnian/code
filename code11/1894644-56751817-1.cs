	public static class MaybeEx
	{
		public static Maybe<T> ToMaybe<T>(this T value)
		{
			return new Maybe<T>(value);
		}
	
		public static T GetValue<T>(this Maybe<T> m, T @default) => m.HasValue ? m.Value : @default;
		public static T GetValue<T>(this Maybe<T> m, Func<T> @default) => m.HasValue ? m.Value : @default();
	
		public static Maybe<U> Select<T, U>(this Maybe<T> m, Func<T, U> k)
		{
			return m.SelectMany(t => k(t).ToMaybe());
		}
	
		public static Maybe<U> SelectMany<T, U>(this Maybe<T> m, Func<T, Maybe<U>> k)
		{
			if (!m.HasValue)
			{
				return Maybe<U>.Nothing;
			}
			return k(m.Value);
		}
	
		public static Maybe<V> SelectMany<T, U, V>(this Maybe<T> @this, Func<T, Maybe<U>> k, Func<T, U, V> s)
		{
			return @this.SelectMany(x => k(x).SelectMany(y => s(x, y).ToMaybe()));
		}
	}
	
	public class Maybe<T>
	{
		public class MissingValueException : Exception { }
	
		public readonly static Maybe<T> Nothing = new Maybe<T>();
	
		private T _value;
		public T Value
		{
			get
			{
				if (!this.HasValue)
				{
					throw new MissingValueException();
				}
				return _value;
			}
			private set
			{
				_value = value;
			}
		}
		public bool HasValue { get; private set; }
	
		public Maybe()
		{
			HasValue = false;
		}
	
		public Maybe(T value)
		{
			Value = value;
			HasValue = true;
		}
	
		public T ValueOrDefault(T @default) => this.HasValue ? this.Value : @default;
		public T ValueOrDefault(Func<T> @default) => this.HasValue ? this.Value : @default();
	
		public static implicit operator Maybe<T>(T v)
		{
			return v.ToMaybe();
		}
	
		public override string ToString()
		{
			return this.HasValue ? this.Value.ToString() : "<null>";
		}
	
		public override bool Equals(object obj)
		{
			if (obj is Maybe<T>)
				return Equals((Maybe<T>)obj);
			return false;
		}
	
		public bool Equals(Maybe<T> obj)
		{
			if (obj == null) return false;
			if (!EqualityComparer<T>.Default.Equals(_value, obj._value)) return false;
			if (!EqualityComparer<bool>.Default.Equals(this.HasValue, obj.HasValue)) return false;
			return true;
		}
	
		public override int GetHashCode()
		{
			int hash = 0;
			hash ^= EqualityComparer<T>.Default.GetHashCode(_value);
			hash ^= EqualityComparer<bool>.Default.GetHashCode(this.HasValue);
			return hash;
		}
	
		public static bool operator ==(Maybe<T> left, Maybe<T> right)
		{
			if (object.ReferenceEquals(left, null))
			{
				return object.ReferenceEquals(right, null);
			}
	
			return left.Equals(right);
		}
	
		public static bool operator !=(Maybe<T> left, Maybe<T> right)
		{
			return !(left == right);
		}
	}
