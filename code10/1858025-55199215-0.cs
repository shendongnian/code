    void F1() {
       if (o is int i)
            WriteLine(i);  // i was initialized, because o is int i returned true
        else
            WriteLine(i); // i was NOT initialized, so you have using of unassigned local variable 'i' here
        WriteLine(i); // the same as above, because i wasn't initialized in all code paths before this statement
    }
    void F2() {
        int i;
        if (o is int) {
            i = (int)o; // just for simulation because 'as' can't unbox
            WriteLine(i); // i was initialized in previous line
        }
        else
            WriteLine(i); // o is not int, so i wasn't initialized => using of unassigned local variable 'i'
        WriteLine(i); // i wasn't initialized in all code paths, using of unassigned local variable 'i'
    }
    void F3() {
        if (!(o is int i))
            WriteLine(i); // Using of unassigned local variable 'i' because o can't be casted to int => !(o is int i)
        else
            WriteLine(i); // compile - i was initialized
        WriteLine(i); // you wrote this statement can be compiled, in fact not, because i is not initialized in all code paths
    }
    void F4() {
        _ = (!(o is int i));
         Console.WriteLine(i); // Use of unassigned local variable 'i', because in case of unsuccessful casting i won't be intialized.
    }
