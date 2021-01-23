    string []lines=System.IO.File.ReadAllLines("Steve.txt");
    string input ;
    while ((input = Console.ReadLine()) != "end")
        {
            int chooseLine;
            int.TryParse(input,out chooseLine);
            if(chooseLine<lines.Length)
             {
               Console.WriteLine(lines[chooseLine]);
             }
        }
