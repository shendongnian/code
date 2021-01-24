csharp
> public class Stack<T>
  {
    public int position => data.Count - 1;
    IList<T> data = new List<T>();
    public void Push(T obj) => data.Add(obj);
    public T Pop()
    {
        var ret = data[position];
        data.RemoveAt(position);
        return ret;
    }
    public override string ToString()
    {
        return $"Num of elements: {data.Count}. {data}";
    }
  }
> public class Animal { }
  public class Bear : Animal{ }
  public class Camel : Animal { }
> var sta = new Stack<Animal>();
  sta.Push(new Animal());
  sta.Push(new Bear());
  sta.Push(new Camel());
> sta
[Num of elements: 3. System.Collections.Generic.List`1[Submission#1+Animal]]
> while (sta.position >=0)
{
    var x = sta.Pop();
    Console.WriteLine($"Popped element type: {x.GetType()}");
}
Popped element type: Submission#3+Camel
Popped element type: Submission#2+Bear
Popped element type: Submission#1+Animal
If any C# genius has a better way around this please let me know, as this is a very annoying restrictions with generics. Generics should allow inherited classes like other languages.
