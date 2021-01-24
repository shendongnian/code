public static void xClearBackgorundColor(this Excel.Range r)
{
    r.ClearFormats();
    r.Interior.ColorIndex = -4142;
}
