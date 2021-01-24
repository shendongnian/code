c#
class MyType
{
}
class MyOtherType
{
}
MyOtherType item = new MyOtherType();
var convertedItem = item as MyType;
In the above example, the compiler has determined that given the types participating in the cast, it's impossible to perform the requested conversion. 
Here providing conversion operators would solve the problem.
**EDIT: working around this error with casting to Object is not recommended, as it defeats the purpose of the type system**
