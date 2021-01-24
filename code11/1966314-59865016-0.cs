c#
    double width, height, woodLength, glassArea; string widthString, heightString;
    Console.Write("Enter the width (as a decimal number): "); // <- Add this
    widthString = Console.ReadLine(); 
    width = double.Parse(widthString); <- this gives the error of: System.FormatException: 'Input string was not in a correct format.' <- Why??? 
    Console.Write("Enter the height (as a decimal number): "); // <- And this
    heightString = Console.ReadLine(); 
    height = double.Parse(heightString);
    woodLength = 2 * (width + height) * 3.25;
    glassArea = 2 * (width * height);
    Console.WriteLine("The length of the wood is " + woodLength + " feet"); 
    Console.WriteLine("The area of the glass is " + glassArea + " square metres");
    Console.ReadLine();
}
Cheers, Ian
