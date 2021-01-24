int length = 5; //5 since i had 5 lines
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
