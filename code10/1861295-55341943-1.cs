c#
var success = false;
var count = 0;
while(!success && count < 10)
{
  try
  {
    DoThing(); // database call, webservice call, etc
    success = true;
  }
  catch(Exception ex)
  {
    Console.WriteLine($"An error occurred doing the thing: {ex}");
    count += 1;
  }
}
// if success is still false, that means we our loop above failed after 10 attempts
if(success == false)
{
  Console.WriteLine("Failed to do the thing after 10 attempts");
}
Of course, replace `Console.WriteLine` with actual log statements.
