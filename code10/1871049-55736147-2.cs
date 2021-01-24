csharp
[Obsolete("Use pattern matching instead.", true)]
public NullToolDataValue NullData => this as NullToolDataValue;
[Obsolete("Use pattern matching instead.", true)]
public DumbellDataValue DumbellData => this as DumbellDataValue;
[Obsolete("Use pattern matching instead.", true)]
public HeartRateDataValue HRData => this as HeartRateDataValue;
[Obsolete("Use pattern matching instead.", true)]
public SomeForceDataValue SomeForceData => this as SomeForceDataValue;
This will make it a compiler error to use them in any code processed by the compiler.  If you're doing any reflection on them, you'll get a runtime exception instead (after step 3 is complete) if you don't also change that code.
## Step 2
Modify every call site that uses those properties to use pattern matching instead.  If all you're doing is what you showed in the question, is should be as simple as this:
csharp
public class DumbellExcercise
{
    public void ToolDataReceived(ToolData data)
    {
        if (data is DumbellDataValue dumbell)
            Collection.Add(dumbell.WeightValue);
        // OR
        if (!(data is DumbellDataValue dumbell))
            return;
        Collection.Add(dumbell.WeightValue);
    }
}
The second variation is not as pretty because the condition has to be parenthesized before it can be negated (hey, at least VB has the `IsNot` keyword; go figure) but you get the same early return that the existing code has.
It looks like you're using at least C# 6.0 because you're using the null-coalescing operator (`?.`), but if you're not using at least 7.0, you can do this, instead:
csharp
public class DumbellExcercise
{
    public void ToolDataReceived(ToolData data)
    {
        DumbellDataValue dumbell = data as DumbellDataValue;
        if (dumbell != null)
            Collection.Add(dumbell.WeightValue);
        // OR
        DumbellDataValue dumbell = data as DumbellDataValue;
        if (dumbell == null)
            return;
        Collection.Add(dumbell.WeightValue);
    }
}
## Step 3
Remove the properties.  If there are no more compiler errors, the properties aren't being used, so you're free to get rid of them.
---
**Additional Note**
The `IsValid` property has a strange duality to it.  It can be assigned by the derived classes but it's also virtual so it can be overridden, too.  You really should pick one.  If it were my decision, I'd keep it virtual and make it read-only.
csharp
public abstract class ToolData
{
    // Continue to assume it's true...
    public virtual bool IsValid => true;
}
public class NullToolDataValue : ToolData
{
    // ...and indicate otherwise as needed.
    public override bool IsValid => false;
}
