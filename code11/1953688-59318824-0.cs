csharp
public static string M(string? text)
public static string M(string text)
In the implementations below I've given each method a different number so I can refer to specific examples unambiguously. It also allows all of the implementations to be present in the same program.
In each of the cases described below, we'll do various things but end up trying to return `text` - so it's the null state of `text` that's important.
## Unconditional return
First, let's just try to return it directly:
csharp
public static string M1(string? text) => text; // Warning
public static string M2(string text) => text;  // No warning
So far, so simple. The nullable state of the parameter at the start of the method is "maybe null" if it's of type `string?` and "not null" if it's of type `string`.
## Simple conditional return
Now let's check for null within the `if` statement condition itself. (I would use the conditional operator, which I believe will have the same effect, but I wanted to stay truer to the question.)
csharp
public static string M3(string? text)
{
    if (text is null)
    {
        return "";
    }
    else
    {
        return text; // No warning
    }
}
public static string M4(string text)
{
    if (text is null)
    {
        return "";
    }
    else
    {
        return text; // No warning
    }
}
Great, so it looks like within an `if` statement where the condition itself checks for nullity, the state of the variable within each branch of the `if` statement can be different: within the `else` block, the state is "not null" in both pieces of code. So in particular, in M3 the state changes from "maybe null" to "not null".
## Conditional return with a local variable
Now let's try to hoist that condition to a local variable:
csharp
public static string M5(string? text)
{
    bool isNull = text is null;
    if (isNull)
    {
        return "";
    }
    else
    {
        return text; // Warning
    }
}
public static string M6(string text)
{
    bool isNull = text is null;
    if (isNull)
    {
        return "";
    }
    else
    {
        return text; // Warning
    }
}
*Both* M5 and M6 issue warnings. So not only do we not get the positive effect of the state change from "maybe null" to "not null" in M5 (as we did in M3)... we get the *opposite* effect in M6, where the state goes from "not null" to "maybe null". That really surprised me.
So it looks like we've learned that:
- Logic around "how a local variable was computed" isn't used to propagate state information. More on that later.
- Introducing a null comparison can warn the compiler that something it previously thought wasn't null might be null after all.
## Unconditional return after an ignored comparison
Let's look at the second of those bullet points, by introducing a comparison before an unconditional return. (So we're completely ignoring the result of the comparison.):
csharp
public static string M7(string? text)
{
    bool ignored = text is null;
    return text; // Warning
}
public static string M8(string text)
{
    bool ignored = text is null;
    return text; // Warning
}
Note how M8 feels like it should be equivalent to M2 - both have a not-null parameter which they return unconditionally - but the introduction of a comparison with null changes the state from "not null" to "maybe null". We can get further evidence of this by trying to dereference `text` before the condition:
csharp
public static string M9(string text)
{
    int length1 = text.Length;   // No warning
    bool ignored = text is null;
    int length2 = text.Length;   // Warning
    return text;                 // No warning
}
Note how the `return` statement doesn't have a warning now: the state *after* executing `text.Length` is "not null" (because if we execute that expression successfully, it couldn't be null). So the `text` parameter starts as "not null" due to its type, becomes "maybe null" due to the null comparison, then becomes "not null" again after `text2.Length`.
## What comparisons affect state?
So that's a comparison of `text is null`... what effect similar comparisons have? Here are four more methods, all starting with a non-nullable string parameter:
csharp
public static string M10(string text)
{
    bool ignored = text == null;
    return text; // Warning
}
public static string M11(string text)
{
    bool ignored = text is object;
    return text; // No warning
}
public static string M12(string text)
{
    bool ignored = text is { };
    return text; // No warning
}
public static string M13(string text)
{
    bool ignored = text != null;
    return text; // Warning
}
So even though `x is object` is now a recommended alternative to `x != null`, they don't have the same effect: only a comparison *with null* (with any of `is`, `==` or `!=`) changes the state from "not null" to "maybe null".
## Why does hoisting the condition have an effect?
Going back to our first bullet point earlier, why don't M5 and M6 take account of the condition which led to the local variable? This doesn't surprise me as much as it appears to surprise others. Building that sort of logic into the compiler and specification is a lot of work, and for relatively little benefit. Here's another example with nothing to do with nullability where inlining something has an effect:
csharp
public static int X1()
{
    if (true)
    {
        return 1;
    }
}
public static int X2()
{
    bool alwaysTrue = true;
    if (alwaysTrue)
    {
        return 1;
    }
    // Error: not all code paths return a value
}
Even though *we* know that `alwaysTrue` will always be true, it doesn't satisfy the requirements in the specification that make the code after the `if` statement unreachable, which is what we need.
Here's another example, around definite assignment:
csharp
public static void X3()
{
    string x;
    bool condition = DateTime.UtcNow.Year == 2020;
    if (condition)
    {
        x = "It's 2020.";
    }
    if (!condition)
    {
        x = "It's not 2020.";
    }
    // Error: x is not definitely assigned
    Console.WriteLine(x);
}
Even though *we* know that the code will enter exactly one of those `if` statement bodies, there's nothing in the spec to work that out. Static analysis tools may well be able to do so, but trying to put that into the language specification would be a bad idea, IMO - it's fine for static analysis tools to have all kinds of heuristics which can evolve over time, but not so much for a language specification.
