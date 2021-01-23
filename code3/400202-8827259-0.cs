      int[] arr_rooms = new int[4];
     Console.WriteLine("Enter room number");
     int number = Int.Parse(Console.ReadLine());
     Console.WriteLine("enter number of bottles");
     int bottles = Int.Parse(Console.ReadLine());
     arr_rooms[number - 1] = bottles; //the -1 is because arrays start at 0
     Console.WriteLine("bottles in room 1 is " + arr_rooms[0].toString());
    
