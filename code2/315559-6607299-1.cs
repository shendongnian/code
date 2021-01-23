    public class MyClass<T, U> {
        // all of these are
        // - generic,
        // - constructed (since two type arguments are supplied), and
        // - bound (since they are constructed):
        private Dictionary<T, U> var1;     // open (since T and U are type parameters)
        private Dictionary<T, int> var2;   // open (since T is a type parameter)
        private Dictionary<int, int> var3; // closed
    }
