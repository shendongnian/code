    foreach(DataGridViewRow row in members_dg.rows)
    {
      // need to get info. This should show u what im looking for. 
      string name = row.Cells[0].Value.ToString();  // first column
      string price = row.Cells[1].Value.ToString();  // second column
      //etc
      Member member = new Member(name, price, ...);
    }
