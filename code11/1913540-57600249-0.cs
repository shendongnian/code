csharp
    public SmallDict<string> smallDict;
    public myClass()
    {
        smallDict = new SmallDict<string>(bigDict);
    }
csharp
    class SmallDict<TKey>
    {
        public readonly Dictionary<TKey, SomeStruct> BigDict;
        public SmallDict(Dictionary<TKey, SomeStruct> bigDict)
        {
            BigDict = bigDict;
        }
        public string this[TKey key]
        {
            get => BigDict[key].ElemFromStruct;
            set {
                var obj = BigDict[key];
                obj.ElemFromStruct = value;
                BigDict[key] = obj;
            }
        }
    }
Use it as follows:
Console.WriteLine(smallDict["key1"]); // Equivalent to printing bigDict[key].ElemFromStruct
smallDict["key1"] = "new value";      // Equivalent to bigDict[key].ElemFromStruct = "new value"
It's a mere wrapper around a dictionary, so if you want more methods than plain indexing, you'll have to do all the plumbing manually.
## Genericity
Notice how `SmallDict` only works for dictionaries of `SomeStruct`...
I would have written a generic **DictionarySlice** class, but any attempt at actual genericity is thwarted by C#'s rigid type system: there is no sastisfying way to genericly tell which property to slice on.
*Possible solutions:*
 - Pass _getters_ and _setters_ as lambdas -- sure you can do that, you would have more code in your lambdas than in your actual class, mind you. It could be useful if you need to slice on many different properties.
 - Make `SomeStruct` implement `IGetSetElemFromStruct` which the generic class would use -- not terribly elegant and potentially extremely cumbersome if you have many properties to slice on.
 - Reflection -- included for completeness, but won't expand on it...
## Large structures
**Avoid** large structs; and more importantly **avoid mutable structs**, which are universally considered a [Very Bad Thing(TM)][1] in C#. *From [Microsoft's design guidelines][2], emphasis mine:*
> In general, structs can be very useful but should only be used for **small**, single, **immutable** values that will not be boxed frequently.
    set {
        var obj = BigDict[key];
        obj.ElemFromStruct = value;
        BigDict[key] = obj;
    }
Notice that in the setter above, I get a copy of the struct, modify it, and copy it back to the dictionary... not great. If it's gonna be large, do yourself a favor and **use a `class`**. You would then simply write:
    set { BigDict[key].ElemFromStruct = value; }
## Non-trivial operations in properties get/set
*This is about the code you wrote as an example*
**Avoid them as much as possible**. There is no definite line saying what can go in properties getters/setters, but creating and populating a dictionary in a `get` is simply way too much by any reasonable standard: imagine if you had to doubt _every_ property access.
  [1]: https://blogs.msdn.microsoft.com/ericlippert/2008/05/14/mutating-readonly-structs/
  [2]: https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/struct
