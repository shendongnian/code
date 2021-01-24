c#
enum TestEnum
{
    One = 1,
    Two = 2,
    Three = 3
}
Use [Enum.Parse(Type, string)][1] to parse the string value as an Enum value.
    string str = "Two";
    TestEnum valueAsEnum = (TestEnum)Enum.Parse(typeof(TestEnum), str);
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.enum.parse?view=netframework-4.8
