c#
public class MatrixElement
{
    public int Value { get; set; }
    public bool isPermanentlyChanged { get; set; }
}
All of the elements in the matrix will have their property `isPermanentlyChanged` to `false` as default value. Then you can fill your matrix like this:
c#
MatrixElement[,] array =
{
    {new MatrixElement { Value = 1 },new MatrixElement { Value = 2 },new MatrixElement { Value = 4 }},
    {new MatrixElement { Value = 6 },new MatrixElement { Value = 6 },new MatrixElement { Value = 7 }}
};
And just check for the value in the indexes you want to change. For instace:
c#
var userValueToChange = 7;
if (array[0, 0].isPermanentlyChanged == false)
{
    array[0, 0].Value = userValueToChange;
    array[0, 0].isPermanentlyChanged = true;
}
else
{
    Console.WriteLine($"Error that element contains a {userValueToChange}, no other values can be entered into this element");
}
This should help you out if I understood you correctly. If not, comment below, so I can edit it out.
