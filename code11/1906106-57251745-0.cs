using WinFormAnimation;
private WinFormAnimation winform = null;
private Animator animator = null;
private void InitAnimator()
{
    var durationOfAnimation = 250000ul;
    winform = new WinFormAnimation.Path(0, 100, durationOfAnimation);
    animator = new Animator(winform);
}
private void ScrollLabel()
{ 
    string textToScroll = sample;
    var maxLabelChars = 115;
    var label = mf.label16;
    if (winform == null)
    {
        InitAnimator();
    }        
    try
    {
        if (mf.button1.Text == "Load.")
        {
            animator.Play(
                    new SafeInvoker<float>(f =>
                    {
                        label.Text =
                            textToScroll.Substring(
                                (int)Math.Max(Math.Ceiling((textToScroll.Length - maxLabelChars) / 100f * f) - 1, 0),
                                maxLabelChars);
                    }, label));
            mf.button1.Text = "Stop."
        }
        if (mf.button1.Text == "Stop.")
        {
            MessageBox.Show("Animator Stop!");
            animator.Stop();
        }
    }
    catch (System.Reflection.TargetInvocationException ex) 
    { 
        ex.Message.ToString(); // This does absolutely nothing
    }
}
This would be a bare minimum solution. You should keep a state instead of relying on checking button texts. And you should do something sensible with the excpetion.
