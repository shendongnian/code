        protected void BindGrid()
        {
            List<FormGridEntity> gridEntities = (DDLProgram.SelectedIndex==-1)
              ?FormSaleSubmit_BAO.GetAllPrograms()
              :FormSaleSubmit_BAO.GetProgramByName(DDLProgram.SelectedValue);
    
            GridForResult.DataSource = gridEntities;
            GridForResult.DataBind();
        }
    
        protected void OnDDLProgramChanged(object sender, EventArgs e)
        {
            BindGrid();
        }
