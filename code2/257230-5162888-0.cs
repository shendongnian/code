    var Set1 = new List<string> { "A1", "A1", "M1", "M2" };
    var Set2 = new List<string> { "M2", "M3", "M1", "A1", "A1", "A2" };
    
    // Remove returns true if it was able to remove it, and it won't be there to be matched again if there's a duplicate in Set1
    bool areAllPresent = Set1.All(i => Set2.Remove(i));
