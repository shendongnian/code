    const int MAX = 10;
    string[] simbolos = new string[MAX] { "!", "#", "$", "%", "&", "=", "@", "~", "»", "«" };
    // Start with some random positions for each column.
    Random r = new Random();
    int column1Index = r.Next(MAX);
    int column2Index = r.Next(MAX);
    int column3Index = r.Next(MAX);
    // Track overall status, and status of each column.
    bool keepSpinning = true;
    bool spin1 = true, spin2 = true, spin3 = true;
    while (keepSpinning)
    {
        Console.WriteLine($"{simbolos[column1Index]} {simbolos[column2Index]} {simbolos[column3Index]}");
        
        if (spin1)
        {
            column1Index = column1Index < MAX - 1 ? column1Index + 1 : 0;
            spin1 = SomethingToDetermineIfColumnShouldKeepSpinning(1);
        }
        
        if (spin2)
        {
            column2Index = column2Index < MAX - 1 ? column2Index + 1 : 0;
            spin2 = SomethingToDetermineIfColumnShouldKeepSpinning(2);
        }
        
        if (spin3)
        {
            column3Index = column3Index < MAX - 1 ? column3Index + 1 : 0; 
            spin3 = SomethingToDetermineIfColumnShouldKeepSpinning(3);
        }
    }
