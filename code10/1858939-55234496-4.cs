public ref string Namelist(int position)
{
     if (array == null)
         throw new ArgumentNullException(nameof(array));
     if (position < 0 || position >= array.Length)
         throw new ArgumentOutOfRangeException(nameof(position));
     return ref array[position];
}
...
// Which allows you to do funky things like this, ect.
object.NameList(1) = "bob";
2. You could make sub/nested classes with indexers 
That's to say, you could create a class that has the features you need with indexers, and make them properties of the main class. So you get something like you envisaged `object.Namelist[0]` and `object.Grades[0]`
<sub> ***Note** : in this situation you could pass the arrays down as references and still access them in the main array like you do*</sub>
---
Example which includes both
**Given**
    public class GenericIndexer<T>
    {
       private T[] _array;
    
       public GenericIndexer(T[] array)
       {
          _array = array;
       }
       public T this[int i]
       {
          get => _array[i];
          set => _array[i] = value;
       }
    }
**Class** 
    public class Bobo
    {
       private int[] _ints = { 2, 3, 4, 5, 5 };
       private string[] _strings = { "asd","asdd","sdf" };
    
       public Bobo()
       {
    
          Strings = new GenericIndexer<string>(_strings);
          Ints = new GenericIndexer<int>(_ints);
       }
       public GenericIndexer<string> Strings ;
       public GenericIndexer<int> Ints ;
    
       public void Test()
       {
          _ints[0] = 234;
       }
    
       public ref int DoInts(int pos)  => ref _ints[pos];
       public ref string DoStrings(int pos)  => ref _strings[pos];
    }
**Usage**
    var bobo = new Bobo();
    bobo.Ints[1] = 234;
    bobo.DoInts(1) = 42;
  [1]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/indexers/
  [2]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/ref-returns
