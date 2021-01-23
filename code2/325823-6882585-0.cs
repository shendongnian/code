    public class CustomTextBox
    {
	public CustomTextBox(CustomTextBox previousSibling)
	{
		PreviousSibling = previousSibling;
	}
	public CustomTextBox PreviousSibling { get; private set; }
	public CustomTextBox PreviousVisibleSibling
	{
		get
		{
			if (PreviousSibling == null)
			{
				return null;
			}
			return PreviousSibling.Visible ? PreviousSibling : PreviousSibling.PreviousVisibleSibling
		}
	}
}
