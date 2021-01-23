        if (this.tBoxFind.Text.Length > 0)
        {
            try
            {
                   this.richTBox.SuspendLayout();
                   this.Cursor = Cursors.WaitCursor;
                   
               string s = this.richTBox.Text;
               System.Text.RegularExpressions.MatchCollection mColl = System.Text.RegularExpressions.Regex.Matches(s, this.tBoxFind.Text);
        
               foreach (System.Text.RegularExpressions.Match g in mColl)
               {
                      this.richTBox.SelectionColor = Color.White;
                      this.richTBox.SelectionBackColor = Color.Blue;
        
                      this.richTBox.Select(g.Index, g.Length);
               }
       }
       finally
       {
             this.richTBox.ResumeLayout();
             this.Cursor = Cursors.Default;
       }
    }
