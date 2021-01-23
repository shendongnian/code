    public class FlashCard
    {
        private readonly string _file;
        private readonly List<string> _lines;
        private int _currentLine;
        public FlashCard(string file)
        {
            _file = file;
            _currentLine = -1;
            // Ensure the list is initialized
            _lines = new List<string>();
            try
            {
                LoadCard();
            }
            catch (Exception ex)
            {
                // either handle or throw some meaningful message that the card
                // could not be loaded.
            }
        }
        private void LoadCard()
        {
            if (!File.Exists(_file))
            {
                // Throw a file not found exception
            }
            using (var reader = File.OpenText(_file))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    _lines.Add(line);
                }
            }
        }
        public string GetPreviousLine()
        {
            // Make sure we're not at the first line already
            if (_currentLine > 0)
            {
                _currentLine--;
            }
            return _lines[_currentLine];
        }
        public string GetNextLine()
        {
            // Make sure we're not at the last line already
            if (_currentLine < _lines.Count - 1)
            {
                _currentLine++;
            }
            return _lines[_currentLine];
        }
    }
