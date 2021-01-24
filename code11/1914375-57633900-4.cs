    // To show just the groups of '17', we can do:
    Console.Write("Group sums where the number is '17': ");
    Console.WriteLine(string.Join(", ", results.Where(t => t.Item1 == 17).Select(t => t.Item2)));
    // Or just write out all the groups:
    Console.WriteLine($"All groups (num, sum): {string.Join(", ", results)}");
    GetKeyFromUser("\n\nDone! Press any key to exit...");
