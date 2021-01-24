 c#
class CaptureContext {
    public int i;
    public void Anonymous() { Func(i); }
}
...
var ctx = new CaptureContext();
for (ctx.i = 0; ctx.i < 10; ctx.i++)
{
    int taskN = ctx.i; // not used, so will probably be removed
    Task.Run(ctx.Anonymous);
}
i.e. there is **only one single `i`**, so if all the anonymous methods get invoked *after* the loop, the value for all of them will be: `10`.
Changing the code to:
 c#
int taskN = i; //local copy instead of i
Task.Run(() => Func(taskN));
gives you very different semantics:
 c#
class CaptureContext {
    public int taskN;
    public void Anonymous() { Func(taskN);}
}
...
for (int i = 0 ; i < 10 ; i++)
{
    var ctx = new CaptureContext();
    ctx.taskN = i;
    Task.Run(ctx.Anonymous);
}
Note that we now have *10* capture context instances each with their own `taskN` value that will be unique per context.
