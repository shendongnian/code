public static int SquareDigits(this int number)
{
    StringBuilder builder = new StringBuilder("");
    foreach (char c in number.ToString())
    {
        byte digit = byte.Parse(c.ToString());
        builder.Append(digit * digit);
    }
    return int.Parse(builder.ToString());
}
Can be called like this: 
int squared = 9119.SquareDigits(); // 811181
Edit:  
To avoid overflow if the input is too big, you could use a `TryX` pattern.
bool TrySquareDigits(int number, out int squared)
{
    StringBuilder builder = new StringBuilder("");
    foreach (char c in number.ToString())
    {
        byte digit = byte.Parse(c.ToString());
        builder.Append(digit * digit);
    }
    return int.TryParse(builder.ToString(), out squared);
}
This can be called like this:  
if (TrySquareDigits(9119, out int result)) { ... } // result = 811181
