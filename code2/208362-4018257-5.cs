    public class Child
    {
    
      protected Child() { } // Constructor to please NHiberante's "Poco" implementation
    
      // internal to prevent other assemblies than the domain assembly from constructing childs
      internal Child(string somethingElse, Parent parent)
      {
        SomethingElse = somethingElse;
        Parent = parent;
      }
    
      // Parent can not be changed by the child itself, because parent is the aggregate root of child.
      public Parent Parent { get; private set; }
    
      public string SomethingElse { get; private set; }
    }
    
    public class Parent
    {
      private readonly ISet<Child> children;
    
      public Parent()
      {
        children = new HashedSet<Child>();
      }
    
      public IEnumerable<Child> Children
      {
        // only provide read access to the collection because manipulating the collection will disturb the domain semantics.
        get { return children; }
      }
    
      // This method wouldn't be called add child, but ExecuteSomeBusinessLogic in real code
      public void AddChild(string somethingElse)
      {
        // child constructor can only be called here because the parent is the aggregate root.
        var child = new Child(somethingElse, parent);
        children.Add(child);
      }
    }
