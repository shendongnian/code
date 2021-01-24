public static T SetToDefault<T>(T the_obj)
{
    return default(T);
}
public static IEnumerable<T> SetToDefault<T>(IEnumerable<T> the_enumerable)
{
    return the_enumerable.Select(value => default(T));
}
FYI I tested my code with this function:
public static void Test()
{
    int myInt = 7;
    IEnumerable<int> myEnumberable = new List<int>() { 1, 4, 8, 9 };
    myInt = SetToDefault(myInt);
    myEnumberable = SetToDefault(myEnumberable);
    Console.WriteLine($"MyInt: {myInt}");
    Console.WriteLine($"MyEnumberable: {String.Join(", ", myEnumberable)}");
}
To add to this, keep in mind that the name ```SetToDefault``` isn't a great choice. When you pass in an int, you will get back an int. You still have to set the value yourself (```myInt = SetToDefault(myInt);```) which is kind of contradictory to what the name of the function implies.
By the way, note that the first function (```T SetToDefault<T>(T the_obj)```) has a parameter which is never used. To work around this (to be fair, small) issue, you could use an extension method:
public static class Extensions {
    public static T GetDefault<T>(this T value) {
        return default(T);
    }
}
Note that even here, you will have to set the value to the return of the function. Returning ```void``` and simply doing ```value = default(T);``` would **not** work for primitive types like ```int```.
var myWhatever = 3.4;
myWhatever = myWhatever.GetDefault();
