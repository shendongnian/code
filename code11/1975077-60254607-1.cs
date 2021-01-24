c#
double sum = 0.0;
int counter = 0;
int total = 3;
while (counter < total)
{
   Console.WriteLine("Enter test score");
   string input = Console.ReadLine();
   double value = double.Parse(input);
   sum += value;
   counter++;
}
Console.WriteLine("Test score average is: {0:N2}", sum / total);
Console.Read();
Or like this if you need the question to be different, you can ask the question outside of the loop and save the result to the `sum` variable. Since we have already asked the question once we can make the `counter` start at 1 instead of 0.
c#
double sum = 0.0;
Console.WriteLine("Enter test score");
string input = Console.ReadLine();
double value = double.Parse(input);
sum = sum + value;
int counter = 1;
int total = 3;
while (counter < total)
{
    Console.WriteLine("Enter another test score");
     input = Console.ReadLine();
     value = double.Parse(input);
    sum += value;
    counter++;
}
Console.WriteLine("Test score average is: {0:N2}", sum / total);
Console.Read();
