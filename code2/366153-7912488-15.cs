            string name = "First Name";// Column name supposed to hide
            for (int i = 0; i < gvEmployees.Columns.Count; i++)
            {
                if (gvEmployees.Columns[i].Text.ToLower().Trim() == name.ToLower().Trim())
                {
                    gvEmployees.Columns[i].Visible = false;
                }
            }
