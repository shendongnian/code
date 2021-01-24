csharp
namespace Utilities
{
    public static class Json
    {
        public static void StaticJsonMethod()
        {
            // Do something
        }
    }
}
you can call that method using `Utilities.Json.StaticJsonMethod()`.
To add another level, you just append the "category" to the namespace:
csharp
namespace Utilities.Formats
{
    public static class Json
    {
        public static void StaticJsonMethod()
        {
            // Do something
        }
    }
}
you can call that method using `Utilities.Formats.Json.StaticJsonMethod()`
