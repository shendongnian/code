    public void klik(object sender, EventArgs e) {
        Bitmap c = this.DrawMandel();
        Graphics gr = CreateGraphics();
        gr.DrawImage(b, 150, 200);
    }
