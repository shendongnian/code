    public static class ContainsAnyExtension
    {
        public static bool ContainsAny<T>(this IEnumerable<T> enumerable, params T[] elements)
        {
            if(enumerable == null) throw new ArgumentNullException("enumerable");
            if(!enumerable.Any || elements.Length == 0) return false;
            foreach(var element in elements){
               if(enumerable.Contains(element)){
                   return true;
               }
            }
            return false;
        }
    }
