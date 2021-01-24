List<String> list = new List<String>();
list.Add(null);
list.Add("asd1");
list.Add(null);
list.Add("asd2");
list.Add(null);
IEnumerable<String> enumerable = list.AsEnumerable();
foreach(var item in enumerable)
{
    Console.WriteLine('"' + item + '"');
}
The output will be:
""
"asd1"
""
"asd2"
""
So as you can see the null values are not removed from the IEnumerable and we still iterate through the empty values. More than likely the IEnumerable is empty.
