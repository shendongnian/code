string n = "M @#.AD()/A?#M";
string tmp = Regex.Replace(n, "[^0-9a-zA-Z]+", "");
Console.WriteLine(tmp);
Removing everything except the string(words).
"[^0-9a-zA-Z]+"
Here is the second version, but in my oppinion you should use Regex for this case.
You can save the special characters in a string array and ask if they exist in the string with ```Contains```.
Code:
string n = "M @#.AD()/A?#M";
string[] chars = new string[] {"?", " ", ",", ".", "/", "!", "@", "#", "$", "%", "^", "&", "*", "'", "\"", ";", "_", "(", ")", ":", "|", "[", "]" };
//Iterate the number of times based on the String array length.
for (int i = 0; i < chars.Length; i++)
{
      if (n.Contains(chars[i]))
      {
           n = n.Replace(chars[i], "");
      }
}
Console.WriteLine(n);
