    public bool AreFilesValid(ListBox.SelectedObjectCollection filenames)
    {
        int count = filenames.Count;
        bool valid = false;
        for(int i=0;i<count;i++)
        {
            string strFile = filenames[i].ToString();
            string[] lines = File.ReadAllLines(strFile);
            if(LinesHaveCorrectLength(lines, 94)) { valid=true;  }
            else  {  valid = false;   }
        }
        return valid;
    }
