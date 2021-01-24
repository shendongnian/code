C#
private void button_Click(object sender, EventArgs e)
{
    // Get reference to the button and the label
    var label = label1;
    var button = button1;
            
    // Get a reference to the animator responsible for this label
    var animator = label.Tag as Animator;
    try
    {
        if (animator?.CurrentStatus == AnimatorStatus.Playing)
        {
            // If playing; stop
            button.Text = @"Play";
            animator.Stop();
        }
        else
        {
            // Load the text and calculate the size of the label in chars as well as expected rows
            string textToScroll = @"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry\'s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
            var labelWidthInChars = (int)(label.Width / label.CreateGraphics().MeasureString("A", label.Font).Width);
            var labelRows = (int)Math.Ceiling((decimal)textToScroll.Length / labelWidthInChars);
            // Create a new animator and set it to animate from (0) to the (number of rows - 1) 
            // in 10 seconds with 10fps maximum callback frequency
            label.Tag = animator = new Animator(new Path(0, labelRows - 1, 10000), FPSLimiterKnownValues.LimitTen);
            button.Text = @"Stop";
            animator.Play(
                new SafeInvoker<float>(f =>
                    {
                        label.Text = textToScroll.Substring(labelWidthInChars * (int)Math.Floor(f));
                    },
                    label));
        }
    }
    catch (Exception exception)
    {
        MessageBox.Show(exception.Message);
    }
}
P.S.: When working with open source projects; if there is an issue tracker for the project; you should probably post your problem there. This will notify the developer of the project (unlike StackOverflow) and therefore probably results in your problem getting solved faster.
https://github.com/falahati/WinFormAnimation/issues
