    using System;
    using System.Windows.Forms;
    
    class UpDownLabel : UpDownBase {
        public UpDownLabel() {
            TextBox box = this.Controls[1] as TextBox;
            box.Enabled = false;
            mLabel = new Label();
            mLabel.Size = box.Size;
            mLabel.Location = box.Location;
            this.Controls.Add(mLabel);
            mLabel.BringToFront();
            Maximum = 100;
            Increment = 1;
        }
        public decimal Value {
            get { return mValue; }
            set { mValue = value; UpdateEditText(); }
        }
        public decimal Increment { get; set; }
        public decimal Minimum { get; set; }
        public decimal Maximum { get; set; }
    
        public override void DownButton() {
            Value = Math.Max(this.Minimum, this.Value - this.Increment);
        }
    
        public override void UpButton() {
            Value = Math.Min(this.Maximum, this.Value + this.Increment);
        }
    
        protected override void UpdateEditText() {
            mLabel.Text = mValue.ToString();
        }
    
        protected override void OnHandleCreated(EventArgs e) {
            base.OnHandleCreated(e);
            UpdateEditText();
        }
        private Label mLabel;
        private decimal mValue = 0;
    
    }
