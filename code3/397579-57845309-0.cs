     public static class ExtensionMethods  
    {
        public static T Previous<T>(this List<T> list, T item) { 
            var index = list.IndexOf(item) - 1;
            return index > -1 ? list[index] : default(T);
        }
        public static T Next<T>(this List<T> list, T item) {
            var index = list.IndexOf(item) + 1;
            return index < list.Count() ? list[index] : default(T);
        }
        public static T Previous<T>(this List<T> list, Func<T, Boolean> lookup) { 
            var item = list.SingleOrDefault(lookup);
            var index = list.IndexOf(item) - 1;
            return index > -1 ? list[index] : default(T);
        }
        public static T Next<T>(this List<T> list, Func<T,Boolean> lookup) {
            var item = list.SingleOrDefault(lookup);
            var index = list.IndexOf(item) + 1;
            return index < list.Count() ? list[index] : default(T);
        }
        public static T PreviousOrFirst<T>(this List<T> list, T item) { 
            if(list.Count() < 1) 
                throw new Exception("No array items!");
            
            var previous = list.Previous(item);
            return previous == null ? list.First() : previous;
        }
        public static T NextOrLast<T>(this List<T> list, T item) { 
            if(list.Count() < 1) 
                throw new Exception("No array items!");
            var next = list.Next(item);
            return next == null ? list.Last() : next;
        }
        public static T PreviousOrFirst<T>(this List<T> list, Func<T,Boolean> lookup) { 
            if(list.Count() < 1) 
                throw new Exception("No array items!");
            var previous = list.Previous(lookup);
            return previous == null ? list.First() : previous;
        }
        public static T NextOrLast<T>(this List<T> list, Func<T,Boolean> lookup) { 
            if(list.Count() < 1) 
                throw new Exception("No array items!");
            var next = list.Next(lookup);
            return next == null ? list.Last() : next;
        }
    }
