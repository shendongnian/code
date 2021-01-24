c#
static void SetProperties(object obj, string[] propertyNames, object value)
{
    var type = obj.GetType();
    foreach (var name in propertyNames)
    {
        var property = type.GetProperty(name);
        property.SetValue(obj, value);        
    }
}
you do it like this:
c#
public void Refactored()
{
    var propertyNames = new[] { 
       nameof(Height), nameof(Weight), nameof(Age), nameof(IQ) 
    };
    SetProperties(this, propertyNames, -0.1m);
}
### Option 2: Reflection, strongly typed, properties specified with lambdas
The helper method:
c#
static void SetProperties<TObj, TProp>(
    TObj obj, 
    TProp value, 
    params Expression<Func<TObj, TProp>>[] properties)
{
    foreach (var lambda in properties)
    {
        var property = (PropertyInfo)((MemberExpression)lambda.Body).Member;
        property.SetValue(obj, value);        
    }
}
and you use it as follows:
c#
public void Refactored()
{
    SetProperties(
        this, 
        -0.1m,
        x => x.Height, x => x.Weight, x => x.Age, x => x.IQ);
}
Using lambdas has the advantage of compiler type- and name-checking, rename refactoring, and picking properties with IntelliSense (when you type `x => x. `).
### Option 3: Reflection.Emit
Accessing properties through Reflection implies performance penalty, which can be affordable or not, depending on your requirements. A much faster way that provides same performance as the original `CopyPasteCode()`, is using dynamic methods built from IL instructions, which you create on the fly once and then use through the lifetime of the application.
However, if you're new to Reflection.Emit: it's a low-level mechanism, and it requires quite a bit of learning. For this reason, it would be much simpler and faster (and safer) to use one of available wrapper libraries. In this case, Marc Gravell's [fast-member](https://github.com/mgravell/fast-member) would be a good choice.
Combined with previous options:
c#
static void SetProperties<TObj, TProp>(
    TObj obj, 
    TProp value, 
    params Expression<Func<TObj, TProp>>[] properties)
{
    var accessor = TypeAccessor.Create(obj.GetType()); 
    
    foreach (var lambda in properties)
    {
        var property = (PropertyInfo)((MemberExpression)lambda.Body).Member;
        accessor[obj, property.Name] = value;      
    }
}
the usage isn't changed:
c#
public void Refactored()
{
    SetProperties(
        this, 
        -0.1m,
        x => x.Height, x => x.Weight, x => x.Age, x => x.IQ);
}
