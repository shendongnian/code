    using System.Drawing;
    using System.Windows.Forms;
    
    enum Alignment { Left = 0, Right = 1};
    static string StringLengthFormat(string inputString, string longestString, 
                                              Alignment alignment=Alignment.Left, string margin="")
    {
        Size textSizeMax = TextRenderer.MeasureText(longestString + margin, SystemFonts.MessageBoxFont);
        Size textSizeCurrent = TextRenderer.MeasureText(inputString, SystemFonts.MessageBoxFont);
        do
        {
            if (alignment == Alignment.Left)
            {
                inputString += " ";
            }
            else
            {
                inputString = " " + inputString;
            }
                
            textSizeCurrent = TextRenderer.MeasureText(inputString, SystemFonts.MessageBoxFont);
        } while (textSizeCurrent.Width < textSizeMax.Width);
        
        return inputString;
    }
