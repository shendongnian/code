    public class NavigateFile
    {
        // Stores the file lines collection
        public IEnumerable<string> CurrentFileLines { get; private set; }
        // Tracks the current line index
        public int CurrentFileLineIndex { get; private set; } = 0;
        // Tracks the next line index
        public int NextFileLineIndex { get; private set; } = 1;
        // Tracks the previous line index
        public int PreviousFileLineIndex { get; private set; } = -1;
        // Tracks the last line index
        public int LastFileLineIndex { get; private set; } = 0;
        // Routine to load the file
        public void LoadFile()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
                if (ofd.ShowDialog() == DialogResult.OK)
                    CurrentFileLines = File.ReadLines(ofd.FileName).Where(line => !string.IsNullOrEmpty(line));
            
            CurrentFileLineIndex = 0;
            NextFileLineIndex = 1;
            PreviousFileLineIndex = -1;
            LastFileLineIndex = CurrentFileLines.Count();
        }
        // Routine return the first line in the file
        public string GoToFirstLine()
        {
            CurrentFileLineIndex = 0;
            return CurrentFileLines.ToList()[CurrentFileLineIndex];
        }
        // Routine return the next line in the file if we can
        public string GoToNextLine()
        {
            if((CurrentFileLineIndex + 1) <= CurrentFileLines.Count() - 1)
            {
                CurrentFileLineIndex++;
                return CurrentFileLines.ToList()[CurrentFileLineIndex];
            }   
            
            return CurrentFileLines.ToList()[CurrentFileLineIndex];
        }
        // Routine return the previous line in the file if we can
        public string GoToPreviousLine()
        {
            if ((CurrentFileLineIndex - 1) >= 0 && (CurrentFileLineIndex - 1) <= CurrentFileLines.Count())
            {
                CurrentFileLineIndex--;
                return CurrentFileLines.ToList()[CurrentFileLineIndex];
            }
            return CurrentFileLines.ToList()[CurrentFileLineIndex];
        }
        // Routine return the last line in the file
        public string GoToLastLine()
        {
            CurrentFileLineIndex = CurrentFileLines.Count() - 1;
            return CurrentFileLines.Last();
        }
    }
