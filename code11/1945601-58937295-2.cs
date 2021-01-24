cs
int NumberCounter = 0;
string NumberLines;
//Code to Read the file and display Each Line seperately.  
System.IO.StreamReader NumbersFile = new System.IO.StreamReader(@"c:\Numbers.txt");
while ((NumberLines = NumbersFile.ReadLine()) != null)
{
   System.Console.WriteLine(NumberLines);
int number = int.Parse(NumberLines);
while(number!=0)
{
s = number%10;
number /= 10;
Console.WriteLine(s);
}
Console.WriteLine(massive.Average());
Console.WriteLine(massive.Max());
Console.WriteLine(massive.Min());
Console.WriteLine(massive.Count());
 
    NumberCounter++;
}
NumbersFile.Close();
System.Console.WriteLine("There Are {0} lines.", NumberCounter);
Console.ReadLine();
