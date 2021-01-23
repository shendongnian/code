     try
     {
        dynamic mycell = Globals.Sheet1.Cells[7, 7];
        double num;
        if (mycell.Value == null) return; //you can use mycell.Text too.
        if (double.TryParse(mycell.Text, out num)) 
        {
              .
              .
              .
        }
    }
    catch (Exception e)
    {
           MessageBox.Show(e.ToString());
    }
