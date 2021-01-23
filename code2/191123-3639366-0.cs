    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern int MapVirtualKey(int uCode, int uMapType);
    
    public static bool RepresentsPrintableChar(this Keys key)
    {
       return !char.IsControl((char)MapVirtualKey((int)key, 2));
    }
    
----------
    Console.WriteLine(Keys.Shift.RepresentsPrintableChar());
    Console.WriteLine(Keys.Enter.RepresentsPrintableChar());
    Console.WriteLine(Keys.Divide.RepresentsPrintableChar());
    Console.WriteLine(Keys.A.RepresentsPrintableChar());
