int i = 0; // This should go first
while (LineIn != null)
{
  Fields = LineIn.Split(',');
  LineIn = Input.ReadLine();
  if (Fields[2] != "0")
  {
    arr[i] = "Guest";
  }
  else if (Fields[2] == "0")
  {
    arr[i] = "Corporate Guest";
  }
  i++;
}
After that, when you are reading the file, you have a nested loop. You are looping 8 times and then on each of those iterations, you loop over each element in the array. Try just a single loop to loop over each element:
// No for loop here
foreach (object element in arr)
{
  if (element != null)
  {
    WriteLine(element.ToString());
  }
}
I hope that helps!
