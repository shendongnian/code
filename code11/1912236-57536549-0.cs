    //gets the length of the array
    int length = sizeof(delete)/sizeof(delete[0]); 
    for(int i=0; i<length; i++){
        if (Directory.Exists(delete[i]))
        {
        Directory.Delete(delete[i]);
        Console.WriteLine("You didnt fail");
        }
        else
        {
        Console.WriteLine("You failed!");
        }
    }
