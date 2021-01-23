    public static List<List<T>> Permutations<T>(List<T> list) {
         List<List<T>> result = new List<List<T>>();
         if ( list.Count == 1 ) { // If only one possible permutation
             result.Add(list); // Add it and return it
             return result;
         }
         foreach(T element in list ) { // For each element in that list
             var remainingList = new List<T>(list);
             remainingList.Remove(element); // Get a list containing everything except of chosen element
             foreach(List<T> permutation in Permutations<T>(remainingList) ) { // Get all possible sub-permutations
                 permutation.Add(element); // Add that element
                 result.Add(permutation);
             }
         }
         return result;
     }
