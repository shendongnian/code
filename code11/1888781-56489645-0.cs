// Wont compile
if (result != 1 && != 12) { }
If you only have a few values to check, I'd use the explicit comparsions. However you can create a collection of values an check if the result is not in the colleciton:
// using System.Linq;
if (!(new []{ 1, 2 /*, ... */ }).Contains(result)) { }
As suggested in the comments you can also write an extension method. This requires a public static class:
public static class ExtensionMethods
{
    public static bool NotIn(this int num, params int[] numbers)
    {
        return !numbers.Contains(num);
    }
}
// usage
result.NotIn(1, 12);
result.NotIn(1, 12, 3, 5, 6);
And if you want to compare not only integers, you can write a generic method:
public static bool NotIn<T>(this T element, params T[] collection)
{
	return !collection.Contains(element);
}
// Works with different types
result.NotIn(1, 2, 3, 4);	
"a".NotIn("b", "c", "aa");
