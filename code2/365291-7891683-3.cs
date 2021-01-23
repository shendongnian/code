            protected void Update_Click(object sender, EventArgs e)
        {
          string MachineTypeID;
          string MachineModelID;
          machine = inputsService.GetMachineSiteDetails(SiteID);
          foreach (Machine Machine in machine)
          {
              try
              {
                  string machinetypeid = Machine.ID.ToString() + "type";
                  string machinemodelid = Machine.ID.ToString() + "model";
                  Control type = MyExtensions.FindControlRecursive(this, machinetypeid);
                  Control model = MyExtensions.FindControlRecursive(this, machinemodelid);
                  RadComboBox machinetype = (RadComboBox) type;
                  RadComboBox machinemodel = (RadComboBox) model;
                  MachineTypeID = machinetype.SelectedValue;
                  MachineModelID = machinemodel.SelectedValue;
                  inputsService.UpdateMachineModels(Machine.ID, MachineModelID);
                  inputsService.UpdateMachineTypes(Machine.ID, MachineTypeID);
              }
              catch (Exception ex)
              {
                  {
                      logger.ErrorFormat(
                          "Update_Click exception occurred when attempting to update the database {0}", ex);
                  }
              }
          }
          //clear out the old table and replace with the newly revized table.
          AssignPlaceHolder.Controls.Clear();  
          AddTableTitles();
          UpdateTableControls();
        }
