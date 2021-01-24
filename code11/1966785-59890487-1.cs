Dictionary<int, long> myDic;
if( !myDic.TryGetValue(100, out var lValue))
{
    lValue = -1;
}
---
**Update**
You could write a custom `TryGetValue` extension method which accepts a `ref TValue value`
public static class DictionaryExtensions
{
	public static bool TryGetValue<TKey,TValue>( this IDictionary<TKey,TValue> dict, TKey key, ref TValue value )
	{
		var result = dict.TryGetValue( key, out var foundValue );
		if ( result )
			value = foundValue;
		return result;
	}
}
live working example at [.net fiddle](https://dotnetfiddle.net/EnCoXG)
