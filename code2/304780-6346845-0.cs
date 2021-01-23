    interface IPaintable // intarface for Lines, Text, Circles, ...
    {
        void OnPaint(Image i); // does the painting
    }
    interface IPaintableCommand // interface for commands 
    {
        void Do(ICollection<IPaintable> painting); // adds line/text/circle to painting
        void Undo(ICollection<IPaintable> painting);  // removes line/text/circle from painting    
    }
