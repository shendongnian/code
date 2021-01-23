                 Word.Range range = _wordApp.Selection.Range;
                 if (range.Text.Contains(title))
                {
                    Word.Range temprange = _document.Range(range.End - 1, range.End); // gets desired range here it gets last character to make superscript in range 
                    temprange.Select();
                    Word.Selection currentSelection = _wordApp.Selection;
                    currentSelection.Font.Superscript = 1;
                }
