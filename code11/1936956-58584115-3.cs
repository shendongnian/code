try {
    Convert.ToInt32(""); // Let's see how ToInt32 behaves for empty strings
} catch (Exception ex ) {
    Console.WriteLine($"{ex.GetType()} -> {ex.Message}");
}
Output:
System.FormatException -> Input string was not in a correct format.
# Possible fix
Something like this should help. 
var ageStr = Console.ReadLine();
int? age = !string.IsNullOrEmpty(ageStr) 
  ? Int32.Parse(ageStr);
  : null;
----
Since you're working with user input `int.TryParse` may be a better candidate.
var ageStr = Console.ReadLine();
int age;
bool success = Int32.TryParse(ageStr, out age);
if( !success ) {
   Console.WriteLine($"'{ageStr}' is not an acceptable value for age.");
}
