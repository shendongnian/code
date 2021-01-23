    using MoreLinq;
    
    string input = "cat";
    var permutations = input.Permutations();
    foreach( var permutation in permutations )
    {
        // 'permutation' is a char[] here, so convert back to a string
        Console.WriteLine( new string(permutation) ); 
    }
