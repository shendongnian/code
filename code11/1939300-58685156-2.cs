var spanned = Regex.Matches(input, ">(.*?)<")
            .Select(m => m.Groups[1].ToString()) // This should find X,間違,う,,Y
            .Where( s => !string.IsNullOrEmpty(s)) // Filter out the empty element
            .SelectMany( s => s) // This gets individual chars from each string
            .Select( ch => $"<span>{ch}</span>"); // Wrap
----
# Test 
string input = "<span>X</span>間違<span>う</span><span>Y</span>";
var spanned = Regex.Matches(input, ">(.*?)<")
            .Select(m => m.Groups[1].ToString())
            .Where( s => !string.IsNullOrEmpty(s))
            .SelectMany( s => s)
            .Select( ch => $"<span>{ch}</span>");
<span>X</span>
<span>間</span>
<span>違</span>
<span>う</span>
<span>Y</span>
