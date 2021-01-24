// Pseudo code
class MyForm : Form
{
    // The field that decides whether to draw the icon
    private bool showWarningIcon = true;
    // The button click handler
    public void OnButtonClick()
    {
        showWarningIcon = false;
        Invalidate();
    }
    // The paint handler
    public override void OnPaint(PaintEventArgs e)
    {
        // Draw other things, then:
        if (showWarningIcon)
        {
            g2.DrawIcon(SystemIcons.Warning, new Rectangle(screenPositionX, screenPositionY, _levelWidth, _levelHeight));
        }
    }
}
