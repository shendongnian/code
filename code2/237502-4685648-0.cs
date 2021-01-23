    public class MyDictionary<T,K> : Dictionary<string,string> // T and K is your own type
    {
        public override bool TryGetValue(T key, out K value)
        {
            string theValue = null;
            // magic conversion of T to a string here
            base.TryGetValue(theConvertedOfjectOfTypeT, out theValue);
            // Do some magic conversion here to make it a K, instead of a string here
            return theConvertedObjectOfTypeK;
        }
    }
