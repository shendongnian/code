public static class VectorExtensions
{
    public static int Sum<TVector>(this IEnumerable<TVector> vectors)
	{
		var type = typeof(TVector);
		if (type == typeof(Vector1))
		{
			return FOREIGN_API.Sum((IEnumerable<Vector1>)vectors);
		}
		else if (type == typeof(Vector2))
		{
			return FOREIGN_API.Sum((IEnumerable<Vector2>)vectors);
		}
        else if (...) // etc.
		
		throw new ArgumentException($"Invalid type of vector {typeof(TVector).Name}.");
	}
}
Then, implementing an `Average` on a mesh is easy (I'm assuming an average is an average of all lists combined):
public class Mesh<T1, T2, T3, T4>
{
    private List<T1> _myVectors1;
    private List<T2> _myVectors2;
    private List<T3> _myVectors3;
    private List<T4> _myVectors4;
	
	public float Average()
	{
	    var sum1 = _myVectors1.Sum();
	    var sum2 = _myVectors2.Sum();
	    var sum3 = _myVectors3.Sum();
	    var sum4 = _myVectors4.Sum();
        return (float)(sum1 + sum2 + sum3 + sum4) / 
            (_myVectors1.Count + _myVectors2.Count + _myVectors3.Count + _myVectors4.Count);
	}
}
This form of typechecking should be fast, as C# heavily optimizes `typeof` calls.
There is a simpler way of writing this that involves `dynamic`:
public static class VectorExtensions
{
    public static int Sum<TVector>(this IEnumerable<TVector> vectors) =>
        FOREIGN_API.Sum((dynamic)vectors);
}
The `dynamic` infrastructure is also faster than many expect due to caching, so you might want to give this solution a try first and then think about something else only when the performance is diagnosed to be an issue. As you can see this takes a ridiculously small amount of code to try out.
=============================================================================
Now let's assume we're looking for the most performant way possible. I'm pretty convinced that there's no way of avoiding runtime typechecking at all. In the above case note, that there are only a handful of typechecks per method invokation. Unless you're calling the `Mesh<,,,>` methods millions of times, that should be fine. But assuming that you might want to do that, there's a way to trick our way out of this.
The idea is to perform all the typechecks required the moment you instantiate a mesh. Let us define helper types that we will call `VectorOperationsN` for all possible `N` in `VectorN` types. It will implement an interface `IVectorOperations<TVector>` that will define basic vector operations you want to have. Let's go with `Sum` for one or many vectors for now, just as examples:
public interface IVectorOperations<TVector>
{
    public int Sum(TVector vector);
    public int Sum(IEnumerable<TVector> vectors);
}
public class VectorOperations1 : IVectorOperations<Vector1>
{
    public int Sum(Vector1 vector) => vector.x;
    public int Sum(IEnumerable<Vector1> vectors) => vectors.Sum(v => Sum(v));
}
public class VectorOperations2 : IVectorOperations<Vector2>
{
    public int Sum(Vector2 vector) => vector.x + vector.y;
    public int Sum(IEnumerable<Vector2> vectors) => vectors.Sum(v => Sum(v));
}
Now we need a way to get the appropriate implementation - this will involve the typecheck:
public static class VectorOperations
{
    public static IVectorOperations<TVector> GetFor<TVector>()
    {
        var type = typeof(TVector);
        if (type == typeof(Vector1))
        {
            return (IVectorOperations<TVector>)new VectorOperations1();
        }
        else if (...) // etc.
    
		throw new ArgumentException($"Invalid type of vector {typeof(TVector).Name}.");
    }
}
Now when we create a mesh we will get an appropriate implementation and then use it all throught our methods:
public class Mesh<T1, T2, T3, T4>
{
    private List<T1> _myVectors1;
    private List<T2> _myVectors2;
    private List<T3> _myVectors3;
    private List<T4> _myVectors4;
    private readonly IVectorOperations<T1> _operations1;
    private readonly IVectorOperations<T2> _operations2;
    private readonly IVectorOperations<T3> _operations3;
    private readonly IVectorOperations<T4> _operations4;
   
    public Mesh()
    {
        _operations1 = VectorOperations.GetFor<T1>();
        _operations2 = VectorOperations.GetFor<T2>();
        _operations3 = VectorOperations.GetFor<T3>();
        _operations4 = VectorOperations.GetFor<T4>();
    }
	public float Average()
	{
	    var sum1 = _operations1.Sum(_myVectors1);
	    var sum2 = _operations2.Sum(_myVectors2);
	    var sum3 = _operations3.Sum(_myVectors3);
	    var sum4 = _operations4.Sum(_myVectors4);
        return (float)(sum1 + sum2 + sum3 + sum4) / 
            (_myVectors1.Count + _myVectors2.Count + _myVectors3.Count + _myVectors4.Count);
	}
}
This works and does a typecheck only when instantiating the mesh. Success! But we can optimize this further using two tricks.
One, we don't need new instances of `IVectorOperations<TVector>` implementations. We can make them singletons and never instantiate more than one object for one type of vector. This is perfectly safe as the implementations are always stateless anyway.
public static class VectorOperations
{
    private static VectorOperations1 Implementation1 = new VectorOperations1();
    private static VectorOperations2 Implementation2 = new VectorOperations2();
    ... // etc.
    public static IVectorOperations<TVector> GetFor<TVector>()
    {
        var type = typeof(TVector);
        if (type == typeof(Vector1))
        {
            return (IVectorOperations<TVector>)Implementation1;
        }
        else if (...) // etc.
    
		throw new ArgumentException($"Invalid type of vector {typeof(TVector).Name}.");
    }
}
Two, we don't really need to typecheck every time we instantiate a new mesh. It's easy to see that the implementations stay the same for every object of a mesh type with equal type arguments. They are static in terms of a single closed generic type. Therefore, we really can make them static:
public class Mesh<T1, T2, T3, T4>
{
    private List<T1> _myVectors1;
    private List<T2> _myVectors2;
    private List<T3> _myVectors3;
    private List<T4> _myVectors4;
    private static readonly IVectorOperations<T1> Operations1 =
        VectorOperations.GetFor<T1>();
    private static readonly IVectorOperations<T2> Operations2 =
        VectorOperations.GetFor<T2>();
    private static readonly IVectorOperations<T3> Operations3 =
        VectorOperations.GetFor<T3>();
    private static readonly IVectorOperations<T4> Operations4 =
        VectorOperations.GetFor<T4>();
    public float Average()
    {
        var sum1 = Operations1.Sum(_myVectors1);
        var sum2 = Operations2.Sum(_myVectors2);
        var sum3 = Operations3.Sum(_myVectors3);
        var sum4 = Operations4.Sum(_myVectors4);
        return (float)(sum1 + sum2 + sum3 + sum4) / 
            (_myVectors1.Count + _myVectors2.Count + _myVectors3.Count + _myVectors4.Count);
    }
}
This way, if there are `N` different vector types, we only ever instantiate `N` objects implementing `IVectorOperations<>` and perform exactly as many additional type checks as there are different mesh types, so at most `4^N`. Individual mesh objects don't take any additional memory, but there are again at most `4^N * 4` references to vector operation implementations.
This still forces you to implement all the vector operations four times for different types. But note that now you've unlocked all options - you have a generic interface that depends on the `TVector` type that you control. Any tricks that inside your `VectorOperations` implementations are allowed. You can be flexible there while being decoupled from the `Mesh` by the `IVectorOperations<TVector>` interface.
Wow this answer is long. Thanks for coming to my TED talk!
