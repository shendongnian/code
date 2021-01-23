        /* To eliminate Duplicate rows */
        private void RemoveDuplicates(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        break;
                    }
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (Convert.ToInt32(dt.Rows[i]["ID"]) == Convert.ToInt32(dt.Rows[j]["ID"]) && dt.Rows[i]["Name"].ToString() == dt.Rows[j]["Name"].ToString())
                        {
                            dt.Rows[i].Delete();
                            break;
                        }
                    }
                }
                dt.AcceptChanges();
            }
        }
