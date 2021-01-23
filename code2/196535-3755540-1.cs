    public IEnumerable<string> GetAllKeys( Dictionary<string,object> dictionary )
    {
        var stackDictionariesToVisit = new Stack<Dictionary<string,object>>();
        stackDictionariesToVisit.Push( dictionary );
 
        // keep visiting iterating until the stack of dictionaries to visit is empty
        while( stackDictionariesToVisit.Count > 0 )
        {
            var nextDictionary = stackDictionariesToVisit.Pop();
            foreach( var keyValuePair in nextDictionary )
            {
                if( keyValuePair.Value is Dictionary<string,object> )
                {
                    stackDictionariesToVisit.Push( 
                         keyValuePair.Value as Dictionary<string,object> );
                }
                else
                {
                    yield return keyValuePair.Key;
                }
            }
        }
    }
