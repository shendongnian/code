    using System.Linq;
    var textboxes = panel.Controls.OfType<TextBox>().Where(c => c.Text != "");
    foreach ( TextBox textbox in textboxes )
    {
      // ...
    }
