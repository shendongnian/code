    using System.Windows.Forms;
    
    /// <summary>
    /// The position of myLabel to the left of the otherControl component when entering 
    /// text "s". 
    /// You must set myLabel.AutoSize = true
    /// </summary>
    /// <param name="s">text</param>
    void WriteText(string s)
    {
        int len = TextRenderer.MeasureText ( s, myLabel.Font ).Width;
        myLabel.Left = otherControl.Left - 5 - len;
        myLabel.Text = s;
    }
