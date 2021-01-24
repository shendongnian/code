csharp
string[] baseArray = { "a", "b", "c", "d", "e", "f" };
var arr = baseArray[1..^2];
Debug.WriteLine(arr[0]);
Debug.WriteLine(baseArray[1]);
arr[0] = "hello";
Debug.WriteLine(arr[0]);
Debug.WriteLine(baseArray[1]);
**Output**
    b
    b
    hello
    b
We can conclude that the **string** array is copied.
However, if we are using an array of objects : 
csharp
public class Foo
{
    public string Bar { get; set; }
}
Foo[] baseArray =
{
    new Foo { Bar = "a" },
    new Foo { Bar = "b" },
    new Foo { Bar = "c" },
    new Foo { Bar = "d" },
    new Foo { Bar = "e" },
    new Foo { Bar = "f" }
};
var arr = baseArray[1..^2];
Debug.WriteLine(arr[0].Bar);
Debug.WriteLine(baseArray[1].Bar);
arr[0].Bar = "hello";
Debug.WriteLine(arr[0].Bar);
Debug.WriteLine(baseArray[1].Bar);
arr[0] = new Foo { Bar = "World" };
Debug.WriteLine(arr[0].Bar);
Debug.WriteLine(baseArray[1].Bar);
This outputs 
    b
    b
    hello
    hello
    World
    hello
Objects in the array aren't copied but referenced.
Setting another object in an array won't affect the other one.
