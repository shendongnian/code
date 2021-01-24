 c#
using System.Linq;
public class C {
    public void M() {
        var query = Data.Where(x => x.Bar == "abc");
    }
    System.Linq.IQueryable<Foo> Data;
    class Foo {
        public string Bar {get;set;}
    }
}
and see what it does; if we [look in sharplab.io](https://sharplab.io/#v2:CYLg1APgAgDABFAjAOgDIEsB2BHA3AWACgioBmBAJjgGE4BvIuJhcqAFjgFkAKASnsbMhANwCGAJzjYArgFNxATzgBeOABFRAF1HIA6gAt5s7gA8VAPjgnkAIQkrVAIlEAjAMaPeBQkIC+gpiQ0LGxkAEkARTlFVwAbWQAeADEAexTLDW1vISgqVJSBHyFmMgREeDtJOgBzWU1cAGc63H8iplbWoA===), we see:
 c#
public void M()
{
    IQueryable<Foo> data = Data;
    ParameterExpression parameterExpression = Expression.Parameter(typeof(Foo), "x");
    BinaryExpression body = Expression.Equal(Expression.Property(parameterExpression, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), Expression.Constant("abc", typeof(string)));
    ParameterExpression[] obj = new ParameterExpression[1];
    obj[0] = parameterExpression;
    IQueryable<Foo> queryable = Queryable.Where(data, Expression.Lambda<Func<Foo, bool>>(body, obj));
}
and we can infer  that you want something similar, i.e.
 c#
var p = Expression.Parameter(typeof(T), "x");
var body = Expression.Equal(
    Expression.PropertyOrField(p, Property),
    Expression.Constant((object)value)
);
var lambda = Expression.Lambda<Func<T, bool>>(body, p);
return query.Where(lambda);
