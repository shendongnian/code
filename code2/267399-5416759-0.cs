    protected void CalculateButton_Click(object sender, EventArgs e)
            {
                Int32 totalMVValue = 0, totalRiskValue = 0;
    
                // Iterate through the Products.Rows property
                foreach (GridViewRow row in GridView1.Rows)
                {
                    // Access the CheckBox
                    CheckBox mvSelectorCheckBox = (CheckBox)row.FindControl("MVSelector");
                    if (mvSelectorCheckBox != null && mvSelectorCheckBox.Checked)
                    {
                        // First, get the primaryId for the selected row
                        int mvValue=
                            Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value);
                        totalMVValue += mvValue;
                    }
    
                    CheckBox riskSelectorCheckBox = (CheckBox)row.FindControl("RiskSelector");
                    if (riskSelectorCheckBox != null && riskSelectorCheckBox.Checked)
                    {
                        // First, get the primaryId for the selected row
                        int riskValue =
                            Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value);
                        totalRiskValue += riskValue;
                    }
                }           
            }
