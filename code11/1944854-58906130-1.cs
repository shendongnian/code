public class Mesh<T1,T2>
{
 // This class is basically going to fail at runtime:
 //   it cannot/will not prevent you from instancing it
 //   as - say - a Mesh<string,int> - which simply cannot
 //   be sensibly implemented.
 //
 // So: many methods will throw Exceptions - but some can be implemented
 //   (and hence: shared amongst all the other variants of the class)
     public List<T1> internalList;
     public int CountElements<List<T1>>() { return internalList.Count; }
     public int DoSomethingToList1<T1>() { ... }
}
public class Mesh<Vector2,T2>
{
     // Now we're saying: HEY compiler! I'll manually override the
     //    generic instance of Mesh<T1,T2> in all cases where the
     //    T1 is a Vector2!
     public int DoSomethingToList1<Vector2>() { ... }
}
---
Or another attempt to find a syntactically valid way to do the same thing (c.f. @Gserg's comment to the main question) - but obviously this fails because C# compiler forbids arbitrary type-casting:
    private List<T1> data;
    public void Main()
    {
        if( typeof(T1) == typeof(Vector2) )
            Main( (List<Vector2>) data );
        else if( typeof(T1) == typeof(Vector3) )
            Main( (List<Vector3>) data );
    }
    public void Main( List<Vector2> dataVector2s )
    {
        ...
    }
    public void Main( List<Vector3> dataVector3s )
    {
        ...
    }
