C#
private MsgBox()
{
    ...
    // Message
    _lblMessage = new List<string>();
    ...
}
Your _lblMessage will always be an empty list so you see no message at all.
You can change your codes like this:
C#
private MsgBox(List<String> messages)
{
    ...
    // Message
    _lblMessage = messages;
    ...
}
public static DialogResult Show(List<String> message, string title)
{
    _msgBox = new MsgBox(message);
    //_msgBox._lblMessage = message;
    ....
}
And also, you'd better set TextBox position otherwise all the TextBox will overlap with each other.
