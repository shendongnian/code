    public static IEnumerable<T> MaxItems<T>(this IEnumerable<T> list, Func<T, int> selector) {  
        var enumerator = list.GetEnumerator();  
  
        if (!enumerator.MoveNext()) {  
            return Enumerable.Empty<T>();  
        }  
  
        var maxItem = enumerator.Current;  
        List<T> maxItems = new List<T>() { maxItem };  
        int maxValue = selector(maxItem);  
  
        while (enumerator.MoveNext()) {  
            var item = enumerator.Current;  
            var value = selector(item);  
  
            if (value > maxValue) {  
                maxValue = value;  
                maxItems = new List<T>() { item };  
            } else if (value == maxValue) {  
                maxItems.Add(item);  
            }  
        }  
  
        return maxItems;  
    }
