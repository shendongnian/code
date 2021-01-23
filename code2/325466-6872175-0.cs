    public class Item
    {
        public string DisplayText { get; set; }
    }
    
    public class ItemViewModel
    {
        private Item _model;
    
        public string DisplayText
        {
            get { return _model.DisplayText; }
        }
    
        public int Score
        {
            get { return MyStaticClass.MyStaticMethod(_model);
        }
    }
