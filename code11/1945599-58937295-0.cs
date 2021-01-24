cs
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
