        public void OrderMedications() 
        {
            if(_medicationManager == null)
            {
                _medicationManager = new MedicationManager();
            }
            int orderID = 1;
            int employeeID = 66;
            int itemID = 1;
            string itemName = "Med_A";
        
            _medicationManager.CreateMedicationOrder(orderID, employeeID, itemID, itemName, Int32.Parse(Quantity_input.Text));
        }
