    public delegate void Notify();
    void SignalTwice(Notify notify) { notify(); notify(); }
    int counter = 0;
    Notify handler = () => { counter++; }
    SignalTwice(handler);
    System.Console.WriteLine(counter); // what should this print?
