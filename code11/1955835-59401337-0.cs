public static class Globals()
{
    public static StatusBarModel GlobalStatus { get; set; }
}
Then whenever you want to alter it you just do 
Globals.GlobalStatus.Status = "something";
Globals.GlobalStatus.P_Value = 14;
does that accomplish what you need?
