    dynamic employee = new ExpandoObject();
    List<ExpandoObject> listOfEmployees = new List<ExpandoObject>();
    employee = "someStrangeString";
    listOfEmployees.Add(employee); // ERROR !!!!
and just as expected, i get the following error on Add.
> Microsoft.CSharp.RuntimeBinder.RuntimeBinderException
  HResult=0x80131500
  Message=The best overloaded method match for 'System.Collections.Generic.List<System.Dynamic.ExpandoObject>.Add(System.Dynamic.ExpandoObject)' has some invalid arguments
  Source=<Cannot evaluate the exception source>
  StackTrace:
<Cannot evaluate the exception stack trace>
**Corrected way of ExpandoObject use**
Following is the method that will take care of the issues with Adding it to the list.
    Parallel.ForEach(collection.Current.ToList(), (ticket) =>
    {
        Console.WriteLine("Ticket----" + ticket);
        dynamic groupWithTickets = new ExpandoObject();
        groupWithTickets.users = ticket; //<---- Assign ticket to users element.
        topGroupsWithMaxTickets.Add(groupWithTickets);
    });
**What was done to fix it?**
When you are working with ExpandoObjects, you have to think of dictionary<string, object> type of a deal. When you declare ExpandoObject, you have to dynamically assign the value to an element (that you define).
[Example from MS site:][1] shows the proper use of ExpandoObject
        dynamic employee, manager;
        employee = new ExpandoObject();
        employee.Name = "John Smith";
        employee.Age = 33;
        manager = new ExpandoObject();
        manager.Name = "Allison Brown";
        manager.Age = 42;
        manager.TeamSize = 10;
Hopefully this resolves your issue.
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.dynamic.expandoobject?view=netframework-4.8
