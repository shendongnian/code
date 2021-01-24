cs
var testClass = typeof(TestClass);
var isSubclass = testClass.IsSubclassOf(typeof(TestBaseClass<int>));
---
If it is the case that you want to check if the class inherits `TestBaseClass` regardless of the used generic type you can try the following:
var testClass = typeof(TestClass);
if (testClass.BaseType.IsGenericType &&
	testClass.BaseType.GetGenericTypeDefinition() == typeof(TestBaseClass<>))
{
    //testClass inherits from TestBaseClass<>
}
