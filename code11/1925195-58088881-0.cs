    public static class SwapperExtensions
    {
        public static T2 Swap<T1,T2>(this T1 original) where T1:class where T2:class,new()
        {
            if (original == null)
                return null;
            
            try
            {
                var result = JsonConvert.SerializeObject(original);
                var newObject = JsonConvert.DeserializeObject<T2>(result);
                return newObject;
            }
            catch(Exception ex)
            {
                throw new ArgumentException("The provided types could not be swapped. See inner exception for details.", ex);
            }
        }
    }
