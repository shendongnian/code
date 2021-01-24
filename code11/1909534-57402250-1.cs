static void Math()
{
    // You wrote some local method named Math which is confusing the compiler
} 
static void Numbers()
{
    // If you specify 'System.Math', now the compiler knows what you mean
    Console.WriteLine("4 ^ 2 = " + System.Math.Pow(4, 2));
    Console.WriteLine("4 ^ 1/2= " + System.Math.Sqrt(4));
}
