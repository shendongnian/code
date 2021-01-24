public static void xClearBackgorundColor(this Excel.Range r)
{
    r.ClearFormats();
    r.Interior.ColorIndex = -4142;
}
or how about if you try to set it to `0`:
public static void xClearBackgorundColor(this Excel.Range r)
{
    r.Interior.ColorIndex = 0;
}
or even like this:
public static void xClearBackgorundColor(this Excel.Range r)
{
    r.Interior.Pattern = Excel.Constants.xlNone;
    r.Interior.TintAndShade = 0;
    r.Interior.PatternTintAndShade = 0;
}
