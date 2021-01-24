    public class AddButton:Button
    {
      public int Count { get; set; } = 0;
      public AddButton()
      {
        // After it's painted, set its text to current Counter
        this.Paint += (s, e) => this.Text = Count.ToString();
        this.Click += (s, e) => this.Text = (++Count).ToString(); 
      }
    }
