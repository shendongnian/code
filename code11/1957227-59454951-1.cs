C#
void Func(StringBuilder s)
{
    s.Append("Hi everyone!");
}
var s = new StringBuilder();
s.Append("a StringBuilder.");
Func(s);
s.ToString(); // "a StringBuilder.Hi everyone!"
