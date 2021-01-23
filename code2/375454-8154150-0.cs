                //unsubsribe the event before populating combobox1
            this.cmbCustomar.SelectedValueChanged -= new System.EventHandler(this.cmbCustomar_SelectedValueChanged);
            cmbCustomar.Datasource = GetCustomerData(_LocationID);
            cmbCustomar.DisplayMember = "Cust_Name";
            cmbCustomar.ValueMember = "Cust_ID";
            //subscribe the event again 
            this.cmbCustomar.SelectedValueChanged += new System.EventHandler(this.cmbCustomar_SelectedValueChanged);
