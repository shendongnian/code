////////////////////////////////////
// Dll1.dll
////////////////////////////////////
namespace Dll1
{
    public class Base
    {
        //The field we are attempting to access
        protected int a;
    }
    public sealed class Main : Base
    {
        public void DoSomething()
        {
            //Can be done sins Main inherits from Base
            base.a = 100;
        }
    }
    public class Invader
    {
        public int GetA()
        {
            var main = new Main();
            main.DoSomething();
            // can not be done sins the field is only accessible by those that inherit from Base
            return main.a;
        } 
    }
}
////////////////////////////////////
// Dll2.dll
////////////////////////////////////
namespace Dll2
{
    public class ADll2Class : Dll1.Base
    {
        public int GetA()
        {
            //Can be done because ADll2Class inherits from Dll1's Base class
            return base.a;
        }
    }
}
[private protected][2] :
Same as protected but, in the example above, Dll2's class, `ADll2Class`, will not be able to access the `a` field because it would be privately protected, in other words only classes from the same dll as `Base` which inherit from `Base` will be able to access `a`.
or you can set it to
[internal][3] :
If the `a` field in the example above was internal, then, same as `private protected`, Dll2's class wont be able to access it but, the `Invader` class in Dll1 will be able to access it sins it's part of the same dll as `Base`.
Note that, sins you mentioned obfuscation, try as hard as you will, the `id` field can still be accessed by others in an obfuscated state with the help of [reflection][4], especially sins you provide a public property `ID`, might as well set everything in your project to `internal`.
  [1]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/protected
  [2]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/private-protected
  [3]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/internal
  [4]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/reflection
