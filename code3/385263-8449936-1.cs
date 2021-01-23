     internal static void AlertBottomRight(string msg, string title, Font fnt)
        {
            SliceCount += 1;
            new ToastForm(5000,
                          title,
                          msg,
                          3) {
                                 Height = (25 + 82) + ((int) (msg.Length / fnt.Size)) * 2,
                                 Visible = true
                             };
        }
        internal static void AlertBottomLeft(string msg, string title, Font fnt)
        {
            SliceCount += 1;
            new ToastForm(5000,
                          title,
                          msg,
                          2) {
                                 Height = (25 + 82) + ((int) (msg.Length / fnt.Size)) * 2,
                                 Visible = true
                             };
        }
        internal static void AlertTopLeft(string msg, string title, Font fnt)
        {
            SliceCount += 1;
            new ToastForm(5000,
                          title,
                          msg,
                          0) {
                                 Height = (25 + 82) + ((int) (msg.Length / fnt.Size)) * 2,
                                 Visible = true
                             };
        }
        internal static void AlertTopRight(string msg, string title, Font fnt)
        {
            SliceCount += 1;
            new ToastForm(5000,
                          title,
                          msg,
                          1) {
                                 Height = (25 + 82) + ((int) (msg.Length / fnt.Size)) * 2,
                                 Visible = true
                             };
        }
