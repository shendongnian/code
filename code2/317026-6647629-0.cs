    protected void BindGrid()
    {
       ...
       if (DDLProgram.SelectedIndex >= 0)
       {
          // program selected
          var programCode = DDLProgram.SelectedValue;
          data = GetProgramByName(programCode);
       }
       else
       {
          // get all programs
          data = GetAllPrograms();
       }
    
       // bind data with grid
    }
