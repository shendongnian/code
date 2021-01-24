private static Dictionary<char, char> map = new Dictionary<char, char> {
	{'A', 'k'}, {'B', 'l'}, {'C', 'm'}, {'D', 'n'}, {'E', 'o'}, {'F', 'p'},
	{'0', 'a'},{'1', 'b'}, {'2', 'c'}, {'3', 'd'},{'4', 'e'}, {'5', 'f'},
	{'6', 'g'},{'7', 'h'},{'8', 'i'}, {'9', 'j'}
};
	
public static string GetMyString(string input)
{
	byte[] b = Convert.FromBase64String(input);
    string source = BitConverter.ToString(b).Replace("-", string.Empty); //leaving the one replace alone for now
			
	return string.Create(source.Length, source, (r, d) => {
		for(int i = 0;i<d.Length;i++)
		{	
			if (map.TryGetValue(d[i], out char n))
			{
				r[i] = n;
			}
			else
			{
				r[i] = Char.ToLower(d[i]);
			}
		}
	});
}
Console.WriteLine(GetMyString("XFEWtnopccImhpHTzGeoeXBg4ws="));
[See it in action.][1]
If I were to use StringBuilder, I know I could easily remove that last `.Replace()` call and the `ToLower()` call:
public static string GetMyString(string input)
{
	byte[] b = Convert.FromBase64String(input);
    string source = BitConverter.ToString(b);
    var result = new StringBuilder(source.Length);
    foreach(char c in source)
    {
        if (c == '-') continue;
	    if (map.TryGetValue(c, out char n))
	    {
			result.Append(n);
		}
		else
		{
			result.Append(Char.ToLower(c));
		}
    }
    return result.ToString();
}
Note it's usually worth checking for lower case per-char while we're already looping through the string, because that's what `ToLower()` would need to do anyway and this saves us allocating and copying a whole new string. 
Also note how I allocated space for the string in the initial `StringBuilder` constructor. I haven't bench marked, but I would expect this to significantly out-perform the other Dictionary/StringBuilder-based answer... but that's what I get for taking longer to answer and providing two solutions ;)
  [1]: https://dotnetfiddle.net/cIeDqV
