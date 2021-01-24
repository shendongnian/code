    int[] phoneAreacode = { 608, 414, 262, 815, 715, 920 };
    double[] phoneCost = { .05, .10, .07, .24, .16, .14 };
    // declaring variables //
    int index;
    int areaCode;
    int callLength;
    bool validAreacode = false;
    // start of actual code //
    
    
    
    do
    {
        Write("Enter in the area code you want to call: ");
        areaCode = Convert.ToInt32(ReadLine());
    
        index = Array.FindIndex(phoneAreacode, w => w == areaCode);
        if (index >= 0)
        {
            validAreacode = true;
        }
        else
        {
            WriteLine("YOU MUST ENTER A VALID AREA CODE!");
        }
    
    } while (!validAreacode);
    
    
    Write("Enter in the length of your call: ");
    callLength = Convert.ToInt32(ReadLine());
    double finalCost = callLength * phoneCost[index];
    WriteLine("Your call to area code " + areaCode + " for " + callLength + " minutes will cost " + finalCost.ToString("C"));
