    using System.Linq;
    // ...
    var arr1 = new[] { 1, 2, 3 };
    var arr2 = new[] { 4, 5, 6 };
    var merged = arr1.Union(arr2);    // This returns an IEnumerable<int>
    
    // If you want an actual array, you can use:
    var mergedArray = merged.ToArray();
