int GetSum(IEnumerable<string> data) 
    => data.Select( txt => { int.TryParse(txt, out var m); return m;}).Sum();
# Example
Console.WriteLine(GetSum(new [] { "100", "200", "xxx" })); //300
Console.WriteLine(GetSum(new [] { "100", "200", "300" })); //600
or
targetComboBox.Text = GetSum( new []{combo1.Text, combo2.Text, ...})?.ToString();
# Null if any is null?
int? GetSum(IEnumerable<string> data) 
    => data.Select( txt => int.TryParse(txt, out var m) is var b && b ? m : (int?)null) is var parsed 
    && parsed.Any(i => i == null) 
        ? null 
        : parsed.Sum();
Console.WriteLine(GetSum(new [] { "100", "200", "xxx" })); //null
Console.WriteLine(GetSum(new [] { "100", "200", "300" })); //600
