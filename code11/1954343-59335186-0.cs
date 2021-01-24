csharp
void printNumbers(int[] arr, string arrayName)
{
    Console.WriteLine("Numbers in " + arrayName + ":");
    foreach(int num in arr){
        Console.WriteLine(num);
    }
}
void Main()
{
    int[] arrayOne = new int[] {10, 20, 30, 40, 50};
    int[] arrayTwo = new int[] {60, 70, 80, 90, 100};
    printNumbers(arrayOne, nameof(arrayOne));
    printNumbers(arrayTwo, nameof(arrayTwo));
}
