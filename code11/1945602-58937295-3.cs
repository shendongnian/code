cs
int NumberCounter = 0;
int[] massive = new int[1000]
string NumberLines;
//Code to Read the file and display Each Line seperately.  
System.IO.StreamReader NumbersFile = new System.IO.StreamReader(@"c:\Numbers.txt");
while ((NumberLines = NumbersFile.ReadLine()) != null)
{
   System.Console.WriteLine(NumberLines);
int number = int.Parse(NumberLines);
int number1 = number;
while(number1!=0)
{
s = number1 %1 0;
number1 /= 10;
Console.WriteLine(s);
}
massive[NumberCounter]=number;
    NumberCounter++;
}
NumbersFile.Close();
Console.WriteLine(massive.Average());
Console.WriteLine(massive.Max());
Console.WriteLine(massive.Min());
 
System.Console.WriteLine("There Are {0} lines.", NumberCounter);
Console.ReadLine();
