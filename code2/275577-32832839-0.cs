    string[] makeBold = new string[4] {a, b, c, d};
  
    foreach (string s in makeBold)
    {
       wApp.Selection.Find.Text = s; //changes with each iteration
       wApp.Selection.Find.Execute(); 
       wApp.Selection.Font.Bold = 1;
       wApp.Selection.Collapse(); //used to 'clear' the selection
       wApp.Selection.Find.ClearFormatting();
    }
