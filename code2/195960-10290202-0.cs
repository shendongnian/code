        foreach (DataGridViewRow item in componentRGOdataGridView.Rows)
        {
            Debug.Write(item.Cells[0].Value.ToString());
            Debug.Write(item.Cells[1].Value.ToString());
            Debug.WriteLine(item.Cells[2].Value.ToString());
        }
