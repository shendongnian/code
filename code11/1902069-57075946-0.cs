 lang-cs
public class Program
{
    public static class IEnumerableExtensions
    {
        public static T MyFirstOrDefault<T>(this IEnumerable<T> enumerable)
        {
            Console.WriteLine("Executing FirstOrDefault()");
            return enumerable.FirstOrDefault();
        }
    }
    public class Type
    {
        public int TypeId { get; set; }
    }
    public static void Main(string[] args)
    {
        var typeList = new List<Type>
        {
            new Type { TypeId = 4 }
        };
        if (typeList.MyFirstOrDefault().TypeId == 1)
        {
            Console.WriteLine("1");
        }
        else if (typeList.MyFirstOrDefault().TypeId == 2)
        {
            Console.WriteLine("2");
        }
        else if (typeList.MyFirstOrDefault().TypeId == 3)
        {
            Console.WriteLine("3");
        }
        else
        {
            Console.WriteLine("other");
        }
    }
}
Console output is
Executing FirstOrDefault()
Executing FirstOrDefault()
Executing FirstOrDefault()
other
I would certainly extract the expression that returns the typeId into a variable - it's better for readability as well.
