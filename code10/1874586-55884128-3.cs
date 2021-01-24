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
