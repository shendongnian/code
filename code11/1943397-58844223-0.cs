c#
public class Bar
{
    public string ProA { get; set; }
    public string ProB { get; set; }
    public Bar(string proa, string prob)
    {
        ProA = proa ?? throw new ArgumentNullException("Invalid proa value");
        ProB = prob ?? throw new ArgumentNullException("Invalid prob value");
    }
}
It's important to note that there is a subtle change in the flow of the logic. I.e. the parameter validation is done only as each property is assigned, rather than prior to any property assignment. But certainly in a class like this, that's completely inconsequential.
It is possible to do something similar with the lambda-expression method approach, with the same caveat (i.e. that assignment and validation become mingled):
c#
public class Bar
{
    public string ProA { get; set; }
    public string ProB { get; set; }
    public Bar(string proa, string prob) : this(prob) => ProA = proa ?? throw new ArgumentNullException("Invalid proa value");
    private Bar(string prob) => ProB = prob ?? throw new ArgumentNullException("Invalid prob value");
}
In other words, add a new constructor for each parameter you want to assign, giving that constructor a single lambda expression to assign that parameter, and having the constructor delegate assignment of the remaining parameters to the next constructor (with more parameters/properties, you can see that the parameter list gets one parameter shorter with each call).
I don't personally find this a real improvement. Yes, the code's more compact. But I'm not really sure it's actually more _readable_. And in an important sense, "simple" and "readable" are the same, or at least very closely related.
