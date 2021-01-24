C#
/// <summary>
///  Displays a message box with specified text.
/// </summary>
public static DialogResult Show(string text)
{
    return ShowCore(null, text, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, 0, false);
}
It means that `.Show(text)` is just a shorthand version of full method call. Therefore, you can achieve only those results that could be achieved by calling the actual `.ShowCore(...)` method.
