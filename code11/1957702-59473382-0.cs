// using static System.Linq.Expressions.Expression
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
Another limitation is that when constructing the expression you may not know how many elements are in the arrays.
