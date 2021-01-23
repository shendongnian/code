    public class Giver
    { 
        private Dictionary<string, WeakReference> cache = 
            new Dictionary<string, WeakReference>();
        public object GetResource(string resourceName)
        {
            WeakReference output;
            object returnValue = null;
    
            if(cache.TryGetValue(resourceName, out output))   
            {
                if(output.IsAlive) returnValue = output.Target;
    
                if(returnValue == null) cache.Remove(resourceName);
            }
    
            if(returnValue == null)
            {
                returnValue = ...; // get the actual resource
    
                cache.Add(resourceName, new WeakReference(returnValue));
            }
    
            return returnValue;
        }
    }
