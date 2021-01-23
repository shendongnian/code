    Literal literal1 = new Literal();
      literal1.Text =
      string.Format("<div style=\"float: left\"><img src='{0}' alt='Test Image'>
      </img></div>",ResolveUrl("~/userdata/2/uploadedimage/batman-for-facebook.jpg"));
      literal1 = new Literal();
      literal1.Text = string.Format("<div style=\"float: left\">{0}</div>", Reader.GetString(0));
      test1.Controls.Add(literal1);
      literal1 = new Literal();
      literal1.Text = "<div style=\"clear: both\">{0}</div>";
      test1.Controls.Add(literal1);
