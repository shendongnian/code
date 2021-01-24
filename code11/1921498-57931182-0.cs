    public class AddButton 
    {
        public int Count { get; set; }
        private void Button_Click(object sender, EventArgs e)
        {
            AddButton ab = (AddButton)sender;
            Count++;
            ab.Text = Count + " Added";
        }
    }
