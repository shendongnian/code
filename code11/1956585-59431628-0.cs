    var first = new System.Threading.Thread(() => {
           //Play sound 1
        Console.Beep(); //Insert your sound here
        }).Start();
    
    System.Threading.Thread.Sleep(500);
    
    new System.Threading.Thread(() => {
             //Play sound 2
        Console.Beep(2000,1000); //Frequency,Milliseconds
        }).Start();
