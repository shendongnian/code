    public struct Relay
    {
        public Relay(Func<string> getText, Action<string> setText)
        {
            this.GetText = getText;
            this.SetText = setText;
        }
        private readonly Func<string> GetText;
        private readonly Action<string> SetText;
        public string Text {
            get { return this.GetText(); }
            set { this.SetText(value); }
        }
    }
    class Example
    {
        private Relay Relay {
            get { return new Relay(() => this.text, t => { this.text = t; }); }
        }
        private string text;
        public Method()
        {
            var r = new Relay();
            r.Text = "hello"; // not a compile error (although there is a null reference)
            // Inappropriately generates a compiler error
            this.Relay.Text = "hello";
            r = this.Relay;
            r.Text = "hello"; // OK
        }
    }
