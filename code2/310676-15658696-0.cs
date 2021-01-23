     private void HighLightGridRows()
            {            
                Debugger.Launch();
                for (int i = 0; i < dtgvAppSettings.Rows.Count; i++)
                {
                    String key = dtgvAppSettings.Rows[i].Cells["Key"].Value.ToString();
                    if (key.ToLower().Contains("applicationpath") == true)
                    {
                        dtgvAppSettings.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                }
            }
