List<dynamic> list = new List<dynamic> { "blah", 15 };
var type = list[0].GetType();
Console.WriteLine(type); // prints out System.String
type = list[1].GetType();
Console.WriteLine(type); // prints out System.Int32
