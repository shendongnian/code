    protected override void OnPaintBackground(PaintEventArgs e)
    {
        var method = typeof(Control).GetMethod("PaintBackground",
            System.Reflection.BindingFlags.Instance |
            System.Reflection.BindingFlags.NonPublic,
            null,
            new Type[] { typeof(PaintEventArgs), typeof(Rectangle), typeof(Color) },
            null);
        //Paint with a default constant back color, here for example Color.Red
        method.Invoke(this, new object[] { e, ClientRectangle, Color.Red });
    }
