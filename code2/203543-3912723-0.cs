    public static class Extensions
    {
        //Using an asynchronous selector, calculate transform for 
        //  input list and callback with result when finished
        public static void AsyncSelect<TIn, TOut>(this List<TIn> list, 
                  Action<TIn, Action<TOut>> selector, 
                  Action<List<TOut>> callback)
        {
            var listOut = new List<TOut>();
            list.AsyncSelectImpl(listOut, selector, callback);
        }
        //internal implementation - hides the creation of the output list
        private static void AsyncSelectImpl<TIn, TOut>(this List<TIn> listIn, 
                  List<TOut> listOut, 
                  Action<TIn, Action<TOut>> selector, 
                  Action<List<TOut>> callback)
        {
            if(listIn.Count == 0)
            {
                callback(listOut); //finished (also if initial list was empty)
            }
            else
            {
                //get first item from list, recurse with rest of list
                var first = listIn[0];
                var rest = listIn.Skip(1).ToList();
                selector(first, result => { 
                                listOut.Add(result); 
                                rest.AsyncSelectImpl(listOut, selector, callback); 
                        });
            }
        }
    }
