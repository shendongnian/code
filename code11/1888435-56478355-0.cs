c#
var gettersDictionary = new Dictionary<string, Delegate>();
var settersDictionary = new Dictionary<string, Delegate>();
foreach (var prop in typeof(Entity).GetProperties())
{
    var getterDelegate = Delegate.CreateDelegate(
        typeof(Func<,>).MakeGenericType(typeof(Entity), prop.PropertyType), 
        prop.GetGetMethod());
    
    gettersDictionary.Add(prop.Name, getterDelegate);
    var setterDelegate = Delegate.CreateDelegate(
        typeof(Action<,>).MakeGenericType(typeof(Entity), prop.PropertyType), 
        prop.GetSetMethod());
    
    settersDictionary.Add(prop.Name, setterDelegate);
}
T GetPropValue<T>(Entity entity, string name)
{
    var getter = (Func<Entity, T>) gettersDictionary[name];
    return getter(entity);
}
void SetPropValue<T>(Entity entity, string name, T value)
{
    var setter = (Action<Entity, T>) settersDictionary[name];
    setter(entity, value);
}
