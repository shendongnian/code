cs
int NumberCounter = 0;
int[] massive = new int[1000];
string NumberLines;
//Code to Read the file and display Each Line seperately.  
System.IO.StreamReader NumbersFile = new System.IO.StreamReader(@"c:\Numbers.txt");
while ((NumberLines = NumbersFile.ReadLine()) != null)
{
    System.Console.WriteLine(NumberLines);
    NumberCounter++;
}
NumbersFile.Close();
System.Console.WriteLine("There Are {0} lines.", NumberCounter);
Console.ReadLine();
for(int i = 0; i < NumberCounter; i++)
{
int j = massive[i];
while(j!=0)
{
s = j%10;
j /= 10;
Console.WriteLine(s);
}
Console.WriteLine(massive.Average());
Console.WriteLine(massive.Max());
Console.WriteLine(massive.Min());
Console.WriteLine(massive.Count());
}
