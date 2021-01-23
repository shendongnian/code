double[,,] doubleArray = new double[10,10,10];
ref double GetElement()
{
   var (x,y,z) = (1,2,3);
   return ref doubleArray[x, y, z];
}
[Eric Lippert's answer](https://stackoverflow.com/a/4543089/120955) goes into detail. I would probably delete this answer, but as it's the accepted answer I cannot delete it.
## Original Answer##
Value types in C# are always passed by value. Objects always have their reference passed by value. This changes in "unsafe" code as Axarydax points out.
The easiest, safest way to avoid this constraint is to make sure that your double is attached to an object somehow.
    public class MyObjectWithADouble {
        public double Element {get; set;} // property is optional, but preferred.
    }
    ...
    var obj = new MyObjectWithADouble();
    obj.Element = 5.0
<strike>I also want to remark that I'm a little confused about how you anticipate assigning a double to a three-dimensional array. You might want to clarify what you're going for.</strike>
I think I understand a little better what you're going for now. You want to return the location of the value in a given array, and then be able to change the value in that location. This pattern breaks some of the expected paradigms of C#, so I would suggest considering other ways to achieve what you're looking for. But if it really makes sense to do it, I'd do something more like this:
    public class 3dArrayLocation {public int X; public int Y; public int Z;}
    ...
    public 3dArrayLocation GetElementLocation(...)
    {
        // calculate x, y, and z
        return new 3dArrayLocation {X = x, Y = y, Z = z}
    }
    ...
 
    var location = GetElementLocation(...);
    doubleArray[location.X, location.Y, location.Z] = 5.0;
