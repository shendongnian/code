    private static string timer1Value = string.Empty;
    private static string timer2Value = string.Empty;
    private static FormWithTimer timer1;
    private static FormWithTimer2 timer2;
    public static void Main()
    {
        var timer1 = new FormWithTimer();
        var timer2 = new FormWithTimer2();
            
        timer1.NewStringAvailable += new EventHandler<BaseClassThatCanRaiseEvent.StringEventArgs>timer1_NewStringAvailable);
            
        timer2.NewStringAvailable += new EventHandler<BaseClassThatCanRaiseEvent.StringEventArgs>(timer1_NewStringAvailable);
        Console.ReadLine();
    }
    static void timer1_NewStringAvailable(object sender, BaseClassThatCanRaiseEvent.StringEventArgs e)
    {
        if (sender == timer1)
        {
            timer1Value = e.Value.ToString();
        }
        else if (sender == timer2)
        {
            timer2Value = e.Value.ToString();
        }
        
        if (timer1Value != String.Empty && timer2Value != String.Empty)
        {
            Console.WriteLine(timer1Value + timer2Value); 
            // Do the string concatenation as you want.
        }
