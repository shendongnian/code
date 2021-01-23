    class Program
    {
        private string _theStringYouWantToSet;
        private StringIterator _stringIter;
        public Program()
        {
            string[] stringsToLoad = { "a", "b", "c" };
            _stringIter = new StringIterator(stringsToLoad);
            _theStringYouWantToSet = _stringIter.GetString();
        }        
        protected void ButtonClickHandler(object sender, MouseButtonEventArgs e)
        {
            _theStringYouWantToSet = _stringIter.GetString();
        }
    }
