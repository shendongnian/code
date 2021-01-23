    public static class ControlExtensions
    {
        public static void Add(this WebControl control, string html)
        {
            control.Controls.Add(new Literal
            {
                Text = html, Mode = LiteralMode.PassThrough
            });
        }
    }
