    [Serializable]
    public class MySurrogate: ISerializationSurrogate
    {
        public MySurrogate() {}
        public MySurrogate(MyControl control)
        {
            CB1Checked = control.checkBox1.Checked;
        }
        public bool CB1Checked { get; set; }
        public Control Create()
        {
            var control = new MyControl();
            control.checkBox1.Checked = CB1Checked;
            return control;
        }
    }
