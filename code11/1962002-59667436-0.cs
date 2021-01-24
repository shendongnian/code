    var answers = new List<string>();
    foreach (var permutation in permutations)
    {
        var original = new List<string> { "A", "B", "C", "D" };
        var variables = original.ToList();
        var perm = new List<string>();
        int count = 0;
        foreach (var i in permutation)
        {
            int index = i - count < 0 ? 0 : i - count;
            variables[index] = variables[index] + variables[index + 1];
            variables.RemoveAt(index + 1);
            if (i < permutation.Count - 1) 
                count++;
            perm.Add(string.Join(" + ", variables));
        }
        answers.Add(string.Join(",", perm));
    }
**Output**
answers contain a list of all permutations.
answers
Count = 6
    [0]: "AB + C + D,ABC + D,ABCD"
    [1]: "AB + C + D,AB + CD,ABCD"
    [2]: "A + BC + D,ABC + D,ABCD"
    [3]: "A + BC + D,A + BCD,ABCD"
    [4]: "A + B + CD,AB + CD,ABCD"
    [5]: "A + B + CD,A + BCD,ABCD"
You can combine and create a single item but this should get you to where you need.
