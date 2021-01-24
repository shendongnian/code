int value = (int)((ITuple)this.delayParameters)[index];
**However**, this will incur two boxing operations: first the tuple as a whole as boxed (as it's cast to `ITuple`), and then the specific tuple member is boxed. Therefore this is probably a **bad idea**!
You'd probably be better off replacing the tuple with an array, or perhaps a custom object like this:
public struct DelayParameters
{
    public int DelayWheel { get; }
    public int DelayDiag { get; }
    public int this[int index] => index switch
    {
        0 => DelayWheel,
        1 => DelayDiag,
        _ => throw new IndexOutOfRangeException(nameof(index)),
    };
    public DelayParameters(int delayWheel, int delayDiag) => 
        (DelayWheel, DelayDiag) = (delayWheel, delayDiag);
}
