     public class Counter
        {
            public TextBox InputTextbox { get; set; }
            public Label CounterLabel { get; set; }
            public Counter(TextBox InputTextbox, Label CounterLabel)
            {
                int NB;
                var tempText = InputTextbox.Text;
                NB = (InputTextbox.MaxLength - tempText.Length);
                CounterNumber counterNumber = new CounterNumber { Number = NB.ToString() };
                CounterLabel.Content = counterNumber;
                if (NB == 0)
                {
                    CounterLabel.Foreground = new SolidColorBrush(Colors.Red);
                }
            }
            class CounterNumber
            {
                public string Number { get; set; }
                public override string ToString()
                {
                    return "[" + Number + "]";
                }
            } 
        }
