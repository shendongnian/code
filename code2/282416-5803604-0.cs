     if (selected != "")
        {
            int find = Array.IndexOf(dict, dict.Where(x => x == selected).FirstOrDefault());
            LimView.Rows[e.RowIndex].Cells[0].Value = dictiddarray[find];
             fRIIBDataSet.Delta.BeginInit(); //
             deltaTableAdapter.Update(fRIIBDataSet.Delta);
             fRIIBDataSet.Delta.EndInit();
        }
