    PrintDocument pd = new PrintDocument();
    pd.PrintPage += (thesender, ev) => {
            ev.Graphics.DrawImage(Image.FromFile("Your Image Path"), 
            //This is to keep image in margins of the Page.
            new PointF(ev.MarginBounds.Left,ev.MarginBounds.Top));
        };
    pd.Print();
