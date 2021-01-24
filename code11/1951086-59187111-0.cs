public enum Test
{
    Small = 1,
    Medium = 2,
    Large = 3,
    Huge = 4,
    UNDEFINED
}
then you can simply convert the number by using 
int integer = 1;
Console.WriteLine((Test)integer). 
output:
Small
