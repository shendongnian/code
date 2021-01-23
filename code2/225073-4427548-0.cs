Ok, so the problem was that old problem of changing a variable that was declared outside the loop on each iteration, and using it inside the loop. I mean, it was somewhat similar to this:MyClass c = new MyClass();
IList`<MyClass>` myClassList = new List`<MyClass>`();
for(int i = 0; i < someInt; i++)
{
    c.SomeProperty = i;
    myClassList.Add(c);
}
// And here every "SomeProperty" is the same for every element in the list, since every element references the same variable.
</pre>
