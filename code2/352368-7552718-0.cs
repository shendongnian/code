    public void klik(object pea, EventArgs e)
    {
        Bitmap c = this.DrawMandel();
        Button btn = pea as Button;
        Graphics gr = btn.CreateGraphics();
        gr.DrawImage(b, 150, 200);
    }
