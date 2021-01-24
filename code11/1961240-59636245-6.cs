csharp
MyClass myClass = new MyClass();
List<MyClass> allClasses = new List<MyClass>();
for(int i =0 ; i < 10 ; i++)
{
   myClass.Value = i;
   allClasses.add(myClass);
}
public class MyClass{public int Value =0 ;}
But correct one is, in the below, we are instantiating new objects with references to those objects instead of using pointing to a single allocation on the heap
csharp
List<MyClass> allClasses = new List<MyClass>();
for(int i =0 ; i < 10 ; i++)
{
   MyClass myClass = new MyClass();
   myClass.Value = i;
   allClasses.add(myClass);
}
public class MyClass{public int Value =0 ;}
Hope I would be clear and correct.
