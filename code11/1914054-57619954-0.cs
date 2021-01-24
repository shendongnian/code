public void TickChecker()
{
    foreach (var con in Controls)
    {
        CheckBox checkBox = con as CheckBox;
        if (null != checkBox)
        {
            checkBox.Checked ^= true;
        }
    }
}
