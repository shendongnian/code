cs
public string GetDate(string input)
{
    return DateTime.Parse(input).ToString("MM/dd/yyyy");
}
The other way, which would be possibly the faster one, is splitting the string on your own and adding the `0` on your own:
cs
public string GetDate(string input)
{
    var items = input.Split('/');
	if(items[0].Length == 1)
	{
		items[0] = "0" + items[0];
	}
	if(items[1].Length == 1)
	{
		items[1] = "0" + items[1];
	}
	
	return string.Join("/", items);
}
---
Note that this is all of course based on the guess, that the input and the required output are strings. 
