c#
public void ProgressBar_MouseDown(object sender, EventArgs e)
{
     int somevariable;
}
Imagine the method as a black box with an input and an output - you can put data in and receive data out, but you don't know what's happening on the inside of the box.
Therefore, when you create `int someVariable` inside the method, nothing else in your code can 'see' this.
To get around this issue, you should use variables inside your class, like so:
c#
public class Program
{
    private int somevariable;
    public void ProgressBar_MouseDown(object sender, EventArgs e)
    {
        // Operate on somevariable
    }
    public void ProgressBar_MouseUp(object sender, EventArgs e)
    {
        int anothervariable = somevariable;
    }
}
If we go back to the black box analogy, now imagine that it has a peephole that it can only look out of. Therefore, your methods (black box) can look out into the class and 'see' the `int somevariable`, but other objects still cannot look inside the method.
You could also pass `somevariable` between methods, however by the looks of it you are responding to UI events, and therefore can't do this easily.
