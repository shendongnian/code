        private RadComboBox AddModelComboBox(Machine machine)
        {
            RadComboBox MachineModelCombo = new RadComboBox();
            machineModel = inputsService.GetMachineModelList(SiteID);
            foreach (MachineModel MachineModel in machineModel)
            {
                if (MachineModel.Name != "NULL")
                {                    
                    MachineModelCombo.Items.Add(new RadComboBoxItem(MachineModel.Name, MachineModel.ID));
                }
            }
            MachineModelCombo.ID = machine.ID.ToString() + "model";
            MachineModelCombo.EnableLoadOnDemand = true;
            MachineModelCombo.EmptyMessage = "Select a Machine Model";
            return MachineModelCombo;
        }
