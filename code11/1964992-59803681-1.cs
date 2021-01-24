// Example without curly braces
if (true)
  Console.Write("true")
else 
  Console.Write("false)
Console.Write("Will Execute After the if else");
and if you have multiple statements / block that needs to be inserted within either if or else, you would use it like this,
if (true)
  Console.WriteLine("true")
else
{
  Conosle.Write("This ");
  Console.Write("Is ");
  Console.Write("False");
}
If you try to write multiple statements within one line, that will result in errors.
    if (true)
        Console.Write("This"); Console.Write("Is"); Console.Write("True"); 
        // Error Here: 'Else Cannot start a statement'. Syntax error ( expected, invalid expression ....
    else
        Console.Write("Whaaa");
**Your Code**
If your first block works and not the second, its because you are running more statements in your else block than you need to. 
    private void WetStepCycleTest(Transform footTransform, RaycastHit footHit, int sCounter)
    {
        if (currentActive == wetStepDecals.Length - 1)
        {
            currentActive = 0;
        }
        else
        {
            currentActive++;
        }
        wetStepDecals[currentActive].transform.position = new Vector3(footTransform.position.x, footHit.point.y, footTransform.position.z);
        wetStepDecals[currentActive].transform.eulerAngles = footTransform.transform.eulerAngles;
        if (sCounter != 0)
        {
            sCounter--;
            Debug.Log("Minus");
        }
    }
