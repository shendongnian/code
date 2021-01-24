csharp
    // The abstraction
    public interface IClass : IDisposable {
        bool DoSomething();
        void Initialize();
    }
    // First class
    public class Class1 : IClass {
        public void Dispose() {
            // Dispose stuff
        }
        public bool DoSomething() {
            //perform operations
            return true; // the result of your operations
        }
        public void Initialize() {
            // Do the initialization
        }
    }
    // Second class
    public class Class2 : IClass {
        public void Dispose() {
            // Dispose Stuff
        }
        public bool DoSomething() {
            //perform operations
            return true; // the result of your operations
        }
        public void Initialize() {
            // Do the initialization
        }
    }
    // Other classes ...
    // ...
    // Your method to perform the operations with a list of classes
    List<IClass> myClassList = new List<IClass>();
    myClassList.Add(new Class1());
    myClassList.Add(new Class2());
    //Adds more classes
    foreach (IClass currentClass in myClassList) {
        currentClass.Initialize();
        if (!currentClass.DoSomething()) {
            break;
        } else {
            currentClass.Dispose();
        }
    }
**Note:** Although I used an interface you could accomplish the same thing using an abstract class (but you should use it only if the classes share some common behaviour, if not it's better to use an interface)
