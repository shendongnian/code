      public bool isCorrect()
        {
            if (checkedListBox1.CheckedItems.Contains("NONE"))
            {
                return false; // wrong answer is selected
            }
            else if (checkedListBox1.CheckedIndices.Count > 0)  
            {
                return true; //at least one correct answer is selected
            }
            else
                return false; // no option is selected
        }
