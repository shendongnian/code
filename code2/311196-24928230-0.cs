    for (int i = 1; i <= Target.Count; i++)
    {
      Excel.Range r = (Excel.Range)Target.Item[i];
      MessageBox.Show(Convert.ToString(r.Value2));
    }
