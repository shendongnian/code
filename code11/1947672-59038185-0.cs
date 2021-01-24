if (jsonString.Trim() == "{}")
{
   // object is empty
}
else
{
   // do deserialization 
}
The `Trim()` is put in just in case there is whitespace surrounding the brackets.
Note you'll have 2 edge cases here:
1. If there is whitespace between the brackets this code will think it's not empty, which is wrong.
2. This doesn't care if the string is valid JSON or not.
