    var s = "This is an extension method";
    // If you want to slice off end characters, just supply a negative startIndex value
    // but no endIndex value (or an endIndex value >= to the source string length).
    Console.WriteLine(s.Slice(-5));
    // Returns "ethod".
    Console.WriteLine(s.Slice(-5, 10));
    // Results in a startIndex of 22 (counting 5 back from the end).
    // Since that is greater than the endIndex of 10, the result is reversed.
    // Returns "m noisnetxe"
    Console.WriteLine(s.Slice(2, 15));
    // Returns "is is an exte"
    
