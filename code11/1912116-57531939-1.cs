int i = 0; // This was extracted from inside the loop. 
while (LineIn != null)
{ 
   // Code omitted...
}
2. When displaying the array to the console, you will be displaying the array content 8 times, since you have a **for** loop counting from 0 to 8 and then have the **foreach** loop interacting over the array. You should have only one of the loops:
// Either this:
for (int i = 0; i < 8; i++)
{
   if (arr[i] != null)
   {
      WriteLine(arr[i].ToString());
   }
}
// ... or ... this:
foreach (object element in arr)
{
   if (element != null)
   {
      WriteLine(element.ToString());
   }
}
I hope this helps. :)
