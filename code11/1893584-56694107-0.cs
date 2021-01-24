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
