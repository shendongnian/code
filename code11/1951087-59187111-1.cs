public enum Test
{
    Small = 1,
    Medium = 2,
    Large = 3,
    Huge = 4
}
then you can simply convert the number by using 
int integer = 1;
if (Enum.IsDefined(typeof(Test), integer) 
{
  Console.WriteLine((Test)integer). 
}
else 
{
  Console.WriteLine("Bad Integer");
}
output:
Small
