C#
var linqLIST = aArray.Where(x => x == "a");
and this is where it gets executed:
C#
Console.WriteLine(linqLIST.Count());
An explict call `ToList()` would execute it the `Linq` immediately:
C#
var linqLIST = aArray.Where(x => x == "a").ToList();
**Regarding the edited question:**
Of course, the `Linq` expression is evaluated in every **foreach** iteration. The issue is not the `Count()`, instead every call to the LINQ expression re-evaluates it. As mentioned above, enumerate it to a `List` and iterate over the list.
**Late edit:**
Concerning **@Eric Lippert**'s critique, I will refer and go into deal for the rest of the OP's questions.
> //Why does this only print out 2 a's and 2 b's, rather than 4 b's?
In the first execution `i = 3` so `aArray[i] = "b";` meaning your array looks like this:
{ "a", "a", "a", "b" }
In the second loop iteration `i--` has now the value *2* and after executing `aArray[i] = "b";` your array is:
{ "a", "a", "b", "b" }
At this point, there are still `a`'s in your array, but the `LINQ` query returns `IEnumerator.MoveNext() == false` and the loop reaches its exit condition. This is the reaons why it _only prints out 2 a's and 2 b's, rather than 4 b's_.
> Why am I able to change what I'm looping over as I'm looping over it?
You are able to do so because the build in code analyser in `Visual Studio` is not detecting that you modify the collection within the loop. At runtime the array is modified, changing the outcome of the `LINQ` query but there is no handling in the implementation of the array iterator so no exception is thrown.
This missing handling seems by design, as arrays are of fixed size oposed to lists where such an exception is thrown at runtime.  
Consider following example code which should be equivalent with your initial code example (before edit):
C#
using System;
using System.Linq;
namespace MyTest {
    class Program {
        static void Main () {
            var aArray = new string[] {
                "a", "a", "a", "a"
            };
            var iterationList = aArray.Where(x => x == "a").ToList();
            foreach (var item in iterationList)
            {
                var index = iterationList.IndexOf(item);
                iterationList.Remove(item);
                iterationList.Insert(index, "b");
            }
            foreach (var arrItem in aArray)
            {
                Console.WriteLine(arrItem);
            }
            Console.ReadKey();
        }
    }
}
This code will compile and iterate the loop once before throwing an `System.InvalidOperationException` with the message:
Collection was modified; enumeration operation may not execute.
Now the reason why the `List` implementation throws this error while enumerating it, is because it follows a basic concept: `For` and `Foreach` are **iterative control flow statements** that need to be **deterministic** at runtime. Furthermore the `Foreach` statement is a `C#` specific implementation of the [iterator pattern](https://en.wikipedia.org/wiki/Iterator_pattern), which defines an algorithm that implies sequential traversal and as such it would not change within the execution. Thus the `List` implementation throws an exception when you modify the collection while enumerating it.
You found one of the ways to modify a loop while iterating it and re-eveluating it in each iteration. This is a bad design choice because you might run into an **infinite loop** if the `LINQ` expression keeps changing the results and never meets an exit condition for the loop. This will make it hard to debug and will not be obvious when reading the code.
In contrast there is the `while` control flow statement which is a conditional construct and is ment to be **non-deterministic** at runtime, having a specific exit condition that is expected to change while execution.
Consider this rewrite base on your example:
C#
using System;
using System.Linq;
namespace MyTest {
    class Program {
        static void Main () {
            var aArray = new string[] {
                "a", "a", "a", "a"
            };
            bool arrayHasACondition(string x) => x == "a";
            while (aArray.Any(arrayHasACondition))
            {
                var index = Array.FindIndex(aArray, arrayHasACondition);
                aArray[index] = "b";
            }
            foreach (var arrItem in aArray)
            {
                Console.WriteLine(arrItem); //Why does this only print out 2 a's and 2 b's, rather than 4 b's?
            }
            Console.ReadKey();
        }
    }
}
I hope this should outline the technical background and explain your false expectations. 
