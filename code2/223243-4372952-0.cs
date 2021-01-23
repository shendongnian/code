    internal abstract class ThemeableForm : Form {
        private Color txtRSSURLBGProperty;
        private Color txtRSSURLFGProperty;
        public Color TxtRSSURLBGProperty
        {
            get { return txtRSSURLBGProperty; }
            set { txtRSSURL.BackColor = value; }
        }
    
        public Color TxtRSSURLFGProperty
        {
            get { return txtRSSURLFGProperty; }
            set { txtRSSURL.ForeColor = value; }
        }
    }
