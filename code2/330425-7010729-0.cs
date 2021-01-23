    public partial class CountdownUserControl : UserControl
    {
        //-----------------------------------------------
        // Private data members
        //-----------------------------------------------
        private Min _Min;
 
        public CountdownUserControl()
        {
            _Min = new _Min(this);
        }
