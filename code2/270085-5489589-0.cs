        StringBuilder sb = new StringBuilder();
        
        if (tb1.Text.Length > 0)
        {
           sb.Append("name like '%' + tb1.Text + "%'");
        }
    
        if (tb2.Text.Length > 0)
        {
           if(sb.Length > 0)
           {
               sb.Append(" and ");
           }
        
           sb.Append("city like '%' + tb2.Text + "%'");
        }
        //.... and so on...
    
        FilterDataView.RowFilter = sb.ToString();
