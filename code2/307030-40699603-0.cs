    var file1 = @"C:\Users\User\Desktop\file1.txt";
    var file2 = @"C:\Users\User\Desktop\file2.txt";
    
    var file1Lines = File.ReadAllLines(file1);
    var file2Lines = File.ReadAllLines(file2).ToList();
    
    // before the copy
    Console.WriteLine("**Before the copy**");
    Console.WriteLine(File.ReadAllText(file2));
    
    foreach (var l in file1Lines)
    {
        file2Lines.Add(l);
    }
    File.WriteAllLines(file2, file2Lines);
    
    // after the copy
    Console.WriteLine("**After the copy**");
    Console.WriteLine(File.ReadAllText(file2));
