    //read all the file into an array, one line per array entry
    string[] lines = File.ReadAllLines(@"c:\temp\values.txt");
    //declare a variable to hold the sum
    int sum = 0;
    //go through the lines one by one...
    foreach(string line in lines)
      //...converting the line to a number and then adding it to the sum
      sum = sum + int.Parse(line);
    //print the result
    Console.WriteLine("sum is " + sum);
