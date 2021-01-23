    class CustomRichTextBox : System.Windows.Forms.RichTextBox {
         public override System.Drawing.Color BackColor {
              get { return System.Drawing.Color.White; }
              set { base.BackColor = System.Drawing.Color.White; }
         }
    }
