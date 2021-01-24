// using static System.Linq.Expressions.Expression;
var a = Parameter(typeof(int[]));
var b = Parameter(typeof(int[]));
var expr1 = Lambda(
    Add(
        Add(
            Add(
                Add(
                    Add(
                        ArrayIndex(a, Constant(0)),
                        ArrayIndex(b, Constant(0))
                    ),
                    ArrayIndex(a,Constant(1))
                ),
                ArrayIndex(b, Constant(1))
            ),
            ArrayIndex(a, Constant(2))
        ),
        ArrayIndex(b, Constant(2))
    ),
    a,
    b
);
var fn = expr1.Compile();
fn.DynamicInvoke(new[] { 1, 2, 3 }, new[] { 4, 5, 6 });
Of course, you will probably want to customize the logic based on what is in the IL.
Also note that this may well be less performant, because the time it takes to compile expression trees is usually at least an order of magnitude greater than simply looping. Unless you can cache the compiled delegates for various values of `size`, and the number of usages justifies this.
---
NB Most of this code comes from the [ExpressionTreeToString library](https://github.com/zspitz/ExpressionTreeToString) that I've written, which can produce the factory method calls needed to create the given expression tree.
// using ExpressionTreeToString;
Expression<Func<int[], int[], int>> expr = (a, b) => a[0] + b[0] + a[1] + b[1] + a[2] + b[2];
Console.WriteLine(expr.ToString("Factory methods"));
