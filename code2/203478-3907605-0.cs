    var passed = StudList.Where(student => student.StatusResult == ResultStatus.Passed);
    var failed = StudList.Where(student => student.StatusResult == ResultStatus.Failed);
    Console.WriteLine("Passed...");
    foreach(var student in passed)
       Console.WriteLine(student.Detail.Name);
    Console.WriteLine("Failed...");
    foreach(var student in failed)
       Console.WriteLine(student.Detail.Name);
