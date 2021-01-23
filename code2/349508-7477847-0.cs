    internal static class Extensions {
      internal static void SetTextLiteral(this Control c, string text) {
        Literal lit = c as Literal;
        if (lit != null)
          lit.Text = text;
      }
    }
    void Sample() {
      e.row.FindControl("myLiteral").SetTextLiteral("textData");
    }
