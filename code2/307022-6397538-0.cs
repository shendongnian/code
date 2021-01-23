Dictionary&lt;string, int&gt; data = new Dictionary&lt;string,int&gt;();
string line = null;
while ((line = ReadLine()) != null) /*ReadLine() is what you currently use to read next line from your input*/
{
 string[] items = line.Split(new char[]{' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);
 string state= items[0].
 int count = int.Parse(items[1]);
 data.Add(state, count);
}
