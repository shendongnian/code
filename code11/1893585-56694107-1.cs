``
/// <summary>
/// This method is specifically used to convert an <see cref="ExpandoObject"/> with a Tree structure to a <see cref="Dictionary{string, object}"/>.
/// </summary>
/// <param name="expando">The <see cref="ExpandoObject"/> to convert</param>
/// <returns>The fully converted <see cref="ExpandoObject"/></returns>
private static Dictionary<string, object> ConvertExpandoObjectToDictionary(ExpandoObject expando) => RecursivelyConvertIDictToDict(expando);
/// <summary>
/// This method takes an <see cref="IDictionary{string, object}"/> and recursively converts it to a <see cref="Dictionary{string, object}"/>. 
/// The idea is that every <see cref="IDictionary{string, object}"/> in the tree will be of type <see cref="Dictionary{string, object}"/> instead of some other implementation like <see cref="ExpandoObject"/>.
/// </summary>
/// <param name="value">The <see cref="IDictionary{string, object}"/> to convert</param>
/// <returns>The fully converted <see cref="Dictionary{string, object}"/></returns>
private static Dictionary<string, object> RecursivelyConvertIDictToDict(IDictionary<string, object> value) =>
    value.ToDictionary(
        keySelector => keySelector.Key,
        elementSelector =>
        {
            // if it's another IDict just go through it recursively
            if (elementSelector.Value is IDictionary<string, object> dict)
            {
                return RecursivelyConvertIDictToDict(dict);
            }
            // if it's an IEnumerable check each element
            if (elementSelector.Value is IEnumerable<object> list)
            {
                // go through all objects in the list
                // if the object is an IDict -> convert it
                // if not keep it as is
                return list
                    .Select(o => o is IDictionary<string, object>
                        ? RecursivelyConvertIDictToDict((IDictionary<string, object>)o)
                        : o
                    );
            }
            // neither an IDict nor an IEnumerable -> it's fine to just return the value it has
            return elementSelector.Value;
        }
    );
``
### Original answer
Soo I finally found the answer after many hours. The problem was (kind of expected) the `ConvertDynamicToDictionary` method.  
My recursive solution only checked if there was another `IDictionary` but what ended up happening was that there was an array of `ExpandoObject`s somewhere in the tree. After adding this check for `IEnumerable`s **it worked** and the method now looks like this:  
private static Dictionary<string, object> ConvertDynamicToDictonary(IDictionary<string, object> value)
{
    return value.ToDictionary(
        p => p.Key,
        p =>
        {
            // if it's another IDict (might be a ExpandoObject or could also be an actual Dict containing ExpandoObjects) just go trough it recursively
            if (p.Value is IDictionary<string, object> dict)
            {
                return ConvertDynamicToDictonary(dict);
            }
            // if it's an IEnumerable, it might have ExpandoObjects inside, so check for that
            if (p.Value is IEnumerable<object> list)
            {
                if (list.Any(o => o is ExpandoObject))
                { 
                    // if it does contain ExpandoObjects, take all of those and also go trough them recursively
                    return list
                        .Where(o => o is ExpandoObject)
                        .Select(o => ConvertDynamicToDictonary((ExpandoObject)o));
                }
            }
            // neither an IDict nor an IEnumerable -> it's probably fine to just return the value it has
            return p.Value;
        } 
    );
}
I'm happy for any critisism on this function as I don't know if I've covered every possibility. Feel free to tell me anything that catches your eye which could be improved. It definitely works in my case so this will be my answer to my own question.
