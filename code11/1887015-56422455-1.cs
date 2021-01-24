      if (CKBX_NuevoPlazo.Checked == true)
                {
                    GridView_ContractFileContent.Columns[1].HeaderStyle.CssClass = "showGridColumn";
                    GridView_ContractFileContent.Columns[1].ItemStyle.CssClass = "showGridColumn";
                }
                else
                {
                    GridView_ContractFileContent.Columns[1].HeaderStyle.CssClass = "hideGridColumn";
                    GridView_ContractFileContent.Columns[1].ItemStyle.CssClass = "hideGridColumn";
                }
