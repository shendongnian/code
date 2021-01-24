	public class HashTable<Key, Value>
	{
		public Maybe<Value> TryGetValue(Key key)
		{
			(bool result, Value value) = TryGetValue(valueSlots, key);
	
			if (result == true)
			{
				return new Maybe<Value>(value); // or value.ToMaybe() // with the extension method
			}
			else
			{
				return Maybe<Value>.Nothing;
			}
		}
	}
