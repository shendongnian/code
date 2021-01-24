// if there are multiple
string keys = ws.Cells[row,keysCol].Value.ToString();
// remove spaces
string keys_normalised = keys.Replace(" ", string.Empty);
Console.WriteLine("Checking that spaces have been removed: " + keys3_normalised + "\n");
		
string[] splits = keys3_normalised.Split(',');
for (int i = 0; i < splits.Length; i++)
{
    Console.WriteLine(splits[i]);
}
This produces the following output in the console:
Checking that spaces have been removed: W456,W234,W167
W456
W234
W167
