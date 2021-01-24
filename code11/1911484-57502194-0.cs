csharp
    var exists1 = info.Exists("Gen", "name", "One key too much"); // false
    var exists2 = info.Exists("Gen", "chapters"); // true
    var value1 = info.Get("Gen", "name", "One key too much"); // null
    var value2 = info.Get("Gen", "chapters"); // "50"
    var valueToSet = "myNewValue";
    var successSet1 = info.TrySet(valueToSet, "Gen", "before", "One key too much"); // false
    var successSet2 = info.TrySet(valueToSet, "Gen", "after"); // true | "Gen" -> "after" set to "myNewValue"
    var dictionary1 = info.FindSubDictionary("Gen", "name", "One key too much"); // null
    var dictionary2 = info.FindSubDictionary("Gen", "chapters"); // "Gen" sub dictionary
I haven't tested it much, nor given much thought into what it should return when, but if you find it useful, it could be something to start to tinker around with.
4 extension methods mostly working together, offering Exists, Get, TrySet and *(what should be)* an internal one to resolve the dictionary tree.
*TrySet:*
csharp
/// <summary>
/// Tries to set a value to any dictionary found at the end of the params keys, or returns false
/// </summary>
public static bool TrySet<T>(this System.Collections.IDictionary dictionary, T value, params string[] keys)
{
    // Get the deepest sub dictionary, set if available
    var subDictionary = dictionary.FindSubDictionary(keys);
    if (subDictionary == null) return false;
            
    subDictionary[keys.Last()] = value;
    return true;
}
*Get:*
csharp
/// <summary>
/// Returns a value from the last key, assuming there is a dictionary available for every key but last
/// </summary>
public static object Get(this System.Collections.IDictionary dictionary, params string[] keys)
{
    var subDictionary = dictionary.FindSubDictionary(keys);
    if (subDictionary == null) return null; // Or throw
                
    return subDictionary[keys.Last()];
}
*Exists:*
csharp
/// <summary>
/// Returns whether the param list of keys has dictionaries all the way down to the final key
/// </summary>
public static bool Exists(this System.Collections.IDictionary dictionary, params string[] keys)
{
    // If we have no keys, we have traversed all the keys, and should have dictionaries all the way down.
    // (needs a fix for initial empty key params though)
    if (keys.Count() == 0) return true;
    // If the dictionary contains the first key in the param list, and the value is another dictionary, 
    // return that dictionary with first key removed (recursing down)
    if (dictionary.Contains(keys.First()) && dictionary[keys.First()] is System.Collections.IDictionary subDictionary)
        return subDictionary.Exists(keys.Skip(1).ToArray());
    // If we didn't have a dictionary, but we have multiple keys left, there are not enough dictionaries for all keys
    if (keys.Count() > 1) return false; 
    // If we get here, we have 1 key, and we have a dictionary, we simply check whether the last value exists,
    // thus completing our recursion
    return dictionary.Contains(keys.First());
}
*FindSubDictionary:*
csharp
/// <summary>
/// Returns the possible dictionary that exists for all keys but last. (should eventually be set to private)
/// </summary>
public static System.Collections.IDictionary FindSubDictionary(this System.Collections.IDictionary dictionary, params string[] keys)
{
    // If it doesn't exist, don't bother
    if (!dictionary.Exists(keys)) return null; // Or throw
    // If we reached end of keys, or got 0 keys, return
    if (keys.Count() == 0) return null; // Or throw
    // Look in the current dictionary if the first key is another dictionary.
    return dictionary[keys.First()] is System.Collections.IDictionary subDictionary
        ? subDictionary.FindSubDictionary(keys.Skip(1).ToArray()) // If it is, follow the subdictionary down after removing the key just used
        : keys.Count() == 1 // If we only have one key remaining, the last key should be for a value in the current dictionary. 
            ? dictionary // Return the current dictionary as it's the proper last one
            : null; // (or throw). If we didn't find a dictionary and we have remaining keys, the dictionary tree is invalid
}
