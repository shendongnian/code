randomNumber = rnd.Next(1, 250);
sw.Write(randomNumber);
sw.Write(" "); // create white space  <------ this line
This line is writing an space always after a number. That means your file will end with and empty space instead a number. This causes a exception in the line
lists.Add(Convert.ToInt32(listInts[j])); 
because for the last line in the file generated listInts[j] = " ".
**First possible solution**
When you're gonna write an empty space to the file, do it only if isn't after write the last number.
Your while loop should look similar to this:
while (count++ < 100000)
{
    randomNumber = rnd.Next(1, 250);
    sw.Write(randomNumber);
    if (count < 100000) //avoid write a white space if is last number to write
    {
        sw.Write(" "); // create white space
    }
    if(lines == 25) //formatting
    {
        sw.WriteLine("");
        lines = 0;
    }
    lines++;
}
**Second possible solution**
In the code you're using to read the file, just remove empty white spaces from each line before split into an array using function .Trim()
String[] listInts = listLines[i].Trim().Split(' ');
instead of current line
String[] listInts = listLines[i].Split(' ');
