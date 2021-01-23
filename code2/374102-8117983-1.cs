    string message = TryAndDoSomething();
    if(!string.IsNullOrEmpty(message)) MessageBox.Show(message);
    ...
    string TryAndDoSomething() {
       // lots
           // of
               // loops
                     return "oops";
    }
