    public void CloneDict(Dictionary<K,V> dictionary) where V:IClonable 
    {
         Dictionary<K,V> clonedOne = new Dictionary<K,V>();
         foreach(KeyValuePair<K,V> pair in dictoinary) {
             clonedOne(pair.Key, (V) pair.Value.Clone()
         }
    }
