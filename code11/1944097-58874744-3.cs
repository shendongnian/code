using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
public class Logs
{
    public DateTime Date { get; set; }
    public string Name { get; set; }
    public string Activity { get; set; }
}
public static void Main(string[] args)
{
    var UserDateTime_TEXT = @"02/02/2018 02:20    
05/02/2018 15:20    
21/02/2018 12:00    
21/02/2018 13:00    
21/02/2018 15:00  ";  
    var UserActivity_TEXT = @"User logs on
User visits page
User goes here
User logs off
User logs on
User visits here";
    
    
    //Equivalent to ReadAllLines
    string[] UserDateTime = UserDateTime_TEXT.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    string[] UserActivity = UserActivity_TEXT.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    
    // ps in your exemple there is more activity than date time... 
    // UserDateTime.Length != UserActivity.Length !!!!!!!!!!!           
    var data = new List<Logs>();
    //in your code you had `x < UserActivity.Length`, what is x?
    for (int i = 0; i < UserDateTime.Length; i++)
    {
        var splitValues =  UserActivity[i].Split(' ');
        var temp =
                new Logs
                {
                    Date = DateTime.ParseExact(UserDateTime[i].Trim(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    Name = splitValues[0], // No space in username. 
                    Activity = string.Join(" ", splitValues.Skip(1))
                };
        data.Add(temp);         
    }
        
    //filter
    var greaterThanThis = new DateTime(2018, 2, 20);
    
    var result = data.Where(x=> x.Date > greaterThanThis);
    foreach(var entry in data){
        Console.WriteLine($"{entry.Name} did  {entry.Activity} at {entry.Date}");
    }
}
[Live Demo](https://dotnetfiddle.net/fa8H2Z)
