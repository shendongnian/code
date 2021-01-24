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
