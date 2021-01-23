    public static T With<T>(this T obj, Expression<Func<T, object>> property, object value)
        where T : ICloneable {
        if (obj == null)
            throw new ArgumentNullException("obj");
        if (property == null)
            throw new ArgumentNullException("property");
        var memExpr = property.Body as MemberExpression;
        if (memExpr == null || !(memExpr.Member is PropertyInfo))
            throw new ArgumentException("Must refer to a property", "property");
        var copy = (T)obj.Clone();
        var propInfo = (PropertyInfo)memExpr.Member;
        propInfo.SetValue(obj, value, null);
        return copy;
    }
    public class Foo : ICloneable {
        public int Id { get; set; } 
        public string Bar { get; set; }
        object ICloneable.Clone() {
            return new Foo { Id = this.Id, Bar = this.Bar };
        }
    }
    public static void Test() {
        var foo = new Foo { Id = 1, Bar = "blah" };
        var newFoo = foo.With(x => x.Bar, "boo-ya");
        Console.WriteLine(newFoo.Bar); //boo-ya
    }
