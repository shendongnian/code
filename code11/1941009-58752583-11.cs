    var fileService = new RealFileService();
    var mover = new FileMover(fileService);
    Console.WriteLine("Please enter customer that you want to test: ");
    string userInput = Console.ReadLine();
    string[] testFiles = Directory.GetFiles("my test file directory");
    mover.MoveFiles("my test file directory", "my in testing directory", userInput);
