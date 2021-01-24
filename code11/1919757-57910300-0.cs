vb.net
Private ReadOnly Property MyGame1 As Game1
    Get
        Static instance As Game1
        If instance Is Nothing Then instance = New Game1()
        Return instance
    End Get
End Property
Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    Console.WriteLine($"{"EVOL".PadRight(53)}{MyGame1.distances.Count()}")
    ' ...
End Sub
2. The Game1 class could be a singleton. The instantiation is done in the C# but only one instance is allowed.
C#
private Game1() { }
private static Game1 instance;
public static Game1 GetInstance()
{
    if (instance == null) instance = new Game1();
    return instance;
}
vb.net
Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    Console.WriteLine($"{"EVOL".PadRight(53)}{Game1.GetInstance().distances.Count()}")
    ' ...
End Sub
3. You use a factory to create the instance, outside of both classes you've provided. (The factory is greatly simplified and typically would return a less derived class than Game1)
c#
public static class Factory
{
    private static Game1 instance;
    public static Game1 GetGame1()
    {
        if (instance == null) instance = new Game1();
        return instance;
    }
}
vb.net
Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    Console.WriteLine($"{"EVOL".PadRight(53)}{Factory.GetGame1().distances.Count}")
    ' ...
End Sub
4. The instantiation is done elsewhere, such as Program.cs or Form1.vb etc. and we don't have enough information, still. You'll need to pass the instance around somehow. In no case should `distances` be static.
