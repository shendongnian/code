cs
        new OverrideOfMyClass_1();
        new OverrideOfMyClass_2();
        new OverrideOfMyClass_3();
        new OverrideOfMyClass_4();
I assume the classes are being compiled into the assembly, in which case it's relatively simple to use reflection to instantiate the classes (though I note you're not keen on it so no offense taken if you don't like this solution).
Here's a reflection based option (assuming usings etc) if you're interested anyway:
cs
var absType = typeof(MyClass);
var subTypes = absType.Assembly.GetTypes()
    .Where(t => t != absType && absType.IsAssignableFrom(t));
foreach(var type in subTypes)
{
    var subObj = Activator.CreateInstance(type) as MyClass;
    // Now you have a subObj if you want to do things with a MyClass object
    Console.WriteLine(subObj.id);
}
