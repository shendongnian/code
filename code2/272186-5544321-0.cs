    public class MyEditableUltraGridController()
    {
        UltraGrid _myGrid;
        public MyEditableUltraGridController(UltraGrid myGrid)
        {
            _myGrid = myGrid;
            _myGrid.InitializeLayout += ... // some common initialization code
            _myGrid.KeyPressed += ... // some keystroke handling code
            ... etc ...
        }
        void InitializeLayout(object sender, EventArgs e)
        {
            ... some specific UltraGrid common initialization code
        }
        ... // some code that make my UltraGrid editable, etc...
    }
