    public static ICollection<ICollection<T>> Permutations<T>(ICollection<T> list) {
        var result = new List<ICollection<T>>();
        if (list.Count == 1) { // If only one possible permutation
            result.Add(list); // Add it and return it
            return result;
        }
        foreach (var element in list) { // For each element in that list
            var remainingList = new List<T>(list);
            remainingList.Remove(element); // Get a list containing everything except of chosen element
            foreach (var permutation in Permutations<T>(remainingList)) { // Get all possible sub-permutations
                permutation.Add(element); // Add that element
                result.Add(permutation);
            }
        }
        return result;
    }
