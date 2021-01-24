        private void VechicleDetails()
        {
            //Sample Method to Generate Some value and 
            //load it to List<VecDetails> and then to ComboBox
            for (int n = 0; n < 10; n++)
            {
                VecDetails ve = new VecDetails();
                ve.stockID = "Stock ID " + (n + 1).ToString();
                ve.basePrice = "Base Price " + (n + 1).ToString();
                lstMasterDetails.Add(ve);
            }
        }
