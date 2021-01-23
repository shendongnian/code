Secondly it seems that you try to solve with generics what should be solved with polymorphism. If both ExistingEmployee and NewEmployee inherit from a base class Employee, your problem would be solved:
public class Application {
  public ExistingEmployee Employee { get; }
}
public class NewApplication {
  public NewEmployee Employee { get; }
}
...
Application app = new Application;
var emp = app.Employee; // this will be of type ExistingEmployee!
