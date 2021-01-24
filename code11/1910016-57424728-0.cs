c#
ItemData beforeItem, currentItem;
Using the code style of the original question this warning can be generated with the following code - note that `a` is declared but never assigned a value:
c#
using System.Diagnostics;
namespace StackOverflow
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            int a;
            int b = 5;
            Debug.Print("{0}", b);
        }
    }
}
Which yields:
txt
> csc Program.cs 
Microsoft (R) Visual C# Compiler version 3.100.19.26603 (9d80dea7)
Copyright (C) Microsoft Corporation. All rights reserved.
Program.cs(9,17): warning CS0168: The variable 'a' is declared but never used
However the example in the original question is basically this - note that `a` is assigned the value `3` but not subsequently used:
c#
using System.Diagnostics;
namespace StackOverflow
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            int a = 3;
            int b = 5;
            Debug.Print("{0}", b);
        }
    }
}
Which yields:
txt
> csc Program.cs 
Microsoft (R) Visual C# Compiler version 3.100.19.26603 (9d80dea7)
Copyright (C) Microsoft Corporation. All rights reserved.
Program.cs(9,17): warning CS0219: The variable 'a' is assigned but its value is never used
Thus the confusion.
Ironically both warnings are thrown by [the same line in the Roslyn compiler](https://github.com/dotnet/roslyn/blob/master/src/Compilers/CSharp/Portable/FlowAnalysis/DefiniteAssignment.cs#L1649):
c#
private void ReportIfUnused(LocalSymbol symbol, bool assigned)
{
    if (!_usedVariables.Contains(symbol))
    {
        if (symbol.DeclarationKind != LocalDeclarationKind.PatternVariable && !string.IsNullOrEmpty(symbol.Name)) // avoid diagnostics for parser-inserted names
        {
            Diagnostics.Add(assigned && _writtenVariables.Contains(symbol) ? ErrorCode.WRN_UnreferencedVarAssg : ErrorCode.WRN_UnreferencedVar, symbol.Locations[0], symbol.Name);
        }
    }
}
To fix the CS0168 warning, delete the definition of `a` or use:
cs
#pragma warning disable 168
int a;
#pragma warning restore 168
To fix the CS0219 warning, delete the definition of `a` or use:
cs
#pragma warning disable 219
int a = 3;
#pragma warning restore 219
To fix the CS0168 warning given in the screen shot delete the definition of `beforeItem` or use:
c#
#pragma warning disable 168
ItemData beforeItem, currentItem;
#pragma warning restore 168
