    void Thread1() {
        lock(myObj) {
 
            if(myObj.Status)
                Console.WriteLine("Status is true");
            // ...
            // myObj.Status is guaranteed to be still true as long as
            // all the code that accesses the property lock myObj.
            if(myObj.Status)
                Console.WriteLine("Status is still true");
        }
    }
