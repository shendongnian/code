    async void ButtonSeries()
    {
      for (int i = 0; i < 10; i++) {
        Button b = new Button();
        b.Text = i.ToString();
        this.Controls.Add(b);
        await b.OnClick();
        this.Controls.Remove(b);
      }
    }
