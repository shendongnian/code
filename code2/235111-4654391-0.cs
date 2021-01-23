    private void clbLang_VisibleChanged(object sender, EventArgs e)
        {
            string lngs = clbLang.Tag as string;
            if (!string.IsNullOrEmpty(lngs))
            {
                string[] langs = lngs.Split(',');
                foreach (string lang in langs)
                {
                    int j = 0;
                    foreach (DataRowView row in clbLang.Items)
                    {
                        if (row != null)
                        {
                            string lng = row[1] as string;
                            if (lng.Trim() == lang)
                            {
                                clbLang.SetItemChecked(j, true);
                                break;
                            }
                        }
                        j++;
                    }
                }
            }
        }
