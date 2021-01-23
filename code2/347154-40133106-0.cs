    private void ColorMe(Color thisColor){
    rng = xlApp.ActiveCell;
    Color mycolour = ColorTranslator.FromHtml("#" + thisColor.Name.Substring(2, 6));
    rng.Interior.Color = Color.FromArgb(mycolour.R, mycolour.G, mycolour.B);
    }
