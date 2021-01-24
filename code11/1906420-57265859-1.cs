c#
class MyString
{
    private string stringValues;
    // Constructors
    public MyString(char[] charArray) { stringValues = new string(charArray); }
    public MyString(string str) { stringValues = str; }
    public MyString() { }
    // ToString for writing to console
    public override string ToString() { return stringValues; }
    // Operator to concat "MyStrings"
    public static MyString operator +(MyString a, MyString b) { return new MyString(a.ToString() + a.ToString()); }
    // Implicit Cast-operator string to MyString
    public static implicit operator MyString(string str) { return new MyString(str); }
    
    // Explicit Cast-operator char-array to MyString
    public static explicit operator MyString(char[] str) { return new MyString(str); }
}
internal static void Main(string[] args)
{
    MyString tmp = new MyString("Initialize by constructor with parameter string");
    Console.WriteLine(tmp);
    tmp = new MyString("Initialize by constructor with parameter char-array".ToCharArray());
    Console.WriteLine(tmp);
    tmp = new MyString("x") + new MyString("+") + new MyString("y");
    Console.WriteLine("Use of '+ operator'" + tmp);
    tmp = "Initialize by creating string and using implicit cast for strings";
    Console.WriteLine(tmp);
    tmp = (MyString)("Initialize by creating char-array and using explicit cast for strings".ToCharArray());
    Console.WriteLine(tmp);
}
