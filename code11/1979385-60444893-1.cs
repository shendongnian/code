cs
using System;
using System.Linq;
using System.Collections.Generic;
public class Program
{
    public static void Main()
    {
        var all = new List<People> { new People { Id = 1, Name = "andy1", }, new People { Id = 2, Name = "andy2", }, new People { Id = 3, Name = "andy3", }, new People { Id = 4, Name = "andy4", }, };
        var someOfThem = new List<People> { new People { Id = 1, Name = null, }, new People { Id = 2, Name = null, } };
        var test = from item in someOfThem
                   join element in all on item.Id equals element.Id
                   select element;
        foreach (var item in test)
            Console.WriteLine("{0}={1}", item.Id, item.Name);
    }
}
public class People
{
    public int Id
    {
        get;
        set;
    }
    public string Name
    {
        get;
        set;
    }
}
The code version would be 
var test = someOfThem.Join(all, item => item.Id, element => element.Id, (item, element) => element);
 as shown in Robert's comment
