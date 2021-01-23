    class DocumentList
    {
        //via a (non-static - read link below) field:
        public List<string> wordList;
        //via a property (read link below):
        public List<string> WordList { get; set; }
        //----------
        public DocumentList(List<string> wordList, .....
        {
            //Sets property
            this.WordList = wordList;
            //Sets field
            this.wordList = wordList;
            //etc.
        }
    }
    
    
    private partial class Window1
    {
        private List<DocumentList> documentList = new List<DocumentList>();
    }
