public class ProtectedTextView : UITextView
{
    public override bool CanPerform(Selector action, NSObject withSender)
    {
        if (action == new Selector("paste:") || (action == new Selector("copy:")))
            return false;
        else
            return base.CanPerform(action, withSender);
    }
}
2. For show/hide, the equivalent of what you are looking at is:
textView.ShouldChangeCharacters = (textField, range, replacementString) =>
{
     string text = textView.Text;
     var result = text.Substring(0, (int) range.Location) + replacementString + text.Substring((int) range.Location + (int) range.Length);
     textView.Text = result;
     return false;
};
I haven't tested the code to work though, so let me know if you have any issues.
