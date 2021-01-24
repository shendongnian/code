c#
public static class MyTextBoxExtension
{
    //To set or clear the password char.
    public static void PasswordCharEnabled(this TextBox textBox, bool enabled, char passChar = '*')
    {
        textBox.PasswordChar = enabled ? passChar : '\0';
    }
    //Just to toggle..
    public static void PasswordCharToggle(this TextBox textBox)
    {
        textBox.PasswordChar = textBox.PasswordChar == '\0' ? '*' : '\0';
    }
}
and in the `ShowHide_Click` event:
c#
private void ShowHide_Click(object sender, EventArgs e)
{
    //to clear the PasswordChar property:
    PassBox.PasswordCharEnabled(false);
    //to set the default asterisk char:
    PassBox.PasswordCharEnabled(true);
    //to set a specific char:
    PassBox.PasswordCharEnabled(true, '^');
    //to set or clear according to the value of a Boolean variable:
    PassBox.PasswordCharEnabled(ShowPass);
    //A bool variable and a char of your choice:
    PassBox.PasswordCharEnabled(ShowPass, '+');
    //or just to toggle...
    PassBox.PasswordCharToggle();
    //Another way to toggle the bool variable first
    //then use its new value to toggle the PasswordChar property.
    PassBox.PasswordCharEnabled(ShowPass = !ShowPass);
}
**Plan B**
_Inheritance_ way, derive a new class from the `TextBox` control and add the new methods:
c#
public class TextBoxEx : TextBox
{
    public TextBoxEx() : base() { }
    //Hide the PasswordChar property and make it read-only
    //since the PasswordCharEnabled method is the setter.
    [Browsable(false)]
    public new char PasswordChar => base.PasswordChar;
            
    public void PasswordCharEnabled(bool enabled, char passChar = '*')
    {
        base.PasswordChar = enabled ? passChar : '\0';
    }
    public void  PasswordCharToggle()
    {
        base.PasswordChar = base.PasswordChar == '\0' ? '*' : '\0';
    }
}
**Plan C**
What's wrong with just:
c#
private void ShowHide_Click(object sender, EventArgs e)
{
    PassBox.PasswordChar = (ShowPass = !ShowPass) == true ? '*' : '\0';
}
The simplest way to toggle the `bool` variable and use its new value to toggle the `PasswordChar` property.
It's your call
