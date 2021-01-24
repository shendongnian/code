    public class MySubclass : Control
    {
        public MySubclass()
        {
            this.Click += new EventHandler( this.Clicked );
        }
        private void Clicked(Object sender, EventArgs e)
        {
            MessageBox.Show( "boop!" );
        }
    }
