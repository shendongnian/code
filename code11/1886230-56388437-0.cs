    string input = "'Test string','abc'";
    string[] listInput = input.Split(",");
    foreach (string input in listInput){
    input = input.trim();
    Console.WriteLine(input);
    }
    Console.ReadLine();
