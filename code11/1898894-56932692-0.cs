if(_isEnum1)
{
    Enum1 e = (Enum1)Enum.Parse(typeof(Enum1), "value");
    HandleEnum1(e);
}
else
{
    Enum2 e = (Enum2)Enum.Parse(typeof(Enum2), "value");
    HandleEnum2(e);
}
where `HandleEnumX` are strongly typed with `EnumX`, so that the compiler knows what's going on, or go completely crazy overboard and use `dynamic`
dynamic e;
if(_isEnum1)
{
	e = (Enum1)Enum.Parse(typeof(Enum1), s);
}
else
{
	e = (Enum2)Enum.Parse(typeof(Enum2), s);
}
// Now e is either Enum1 or Enum2, resolved at runtime.
However, this seems wildly overcomplicated and more of a thought experiment than real code you should be pushing to production. You should probably rethink your design of this part of the program. At the very least, you might want to wrap your enums in a class to allow a more flexible design.
As a side note - you're using `TryParse` but never testing the returned value, so I took the liberty of exchanging them to `Parse`.
