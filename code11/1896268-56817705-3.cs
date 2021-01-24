C#
void Z()
{
    string key_string = "F10";
    if (Enum.TryParse(key_string, out Key key))
    {
        if (Keyboard.IsKeyDown(key))
        {
            // some logic
        }
    }
    else
    {
        // ERROR: the string couldn't be converted to Key
    }
}
