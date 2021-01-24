public interface ITestable
{
    string Name {get;set;}
    string Description {get;set;}
    Task Test();
}
1. Now you could search for classes that implement the interface using reflection.
2. From the list of classes you could filter the classes that are not abstract
3. Then you could still filter and get the classes that have a no argument constructor
Now using reflection, you could instantiate the classes to get objects
