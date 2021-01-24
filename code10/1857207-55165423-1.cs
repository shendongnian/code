    class Form2
    {
        public Form1 Form1 {get; set;}
        protected void ShowForm3InsideForm1()
        {
            this.Form1.ShowForm3();
        }
    }
