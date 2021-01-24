    using System.Linq;
    ...
    string[] weekdays = new string[7] { "Monday", "Tuesday", "Wednesday",
            "Thursday", "Friday", "Saturday", "Sunday"};
    Console.WriteLine("Give me a day: ");
    String day= Console.ReadLine();
   
    if( weekdays.Any(x => x == day))
         break;
    else
    {
          Console.WriteLine("Try again");
          day = Console.ReadLine();
    }
