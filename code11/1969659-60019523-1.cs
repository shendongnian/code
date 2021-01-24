    using System.Linq;
    ...
    string[] weekdays = new string[7] { "Monday", "Tuesday", "Wednesday",
            "Thursday", "Friday", "Saturday", "Sunday"};
    Console.WriteLine("Give me a day: ");
    String day= Console.ReadLine();
    //No need to iterate over array and check day exists in array or not.
    //You can use .Contains() method as well.
    if(weekdays.Any(x => x == day))   
         break;
    else
    {
          Console.WriteLine("Try again");
          day = Console.ReadLine();
    }
