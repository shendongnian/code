        public void ExecuteStoredProcedure()
        {
            try
            {
                // db context variable
                var context = _manufacturingDbContext;
                const string recordType = "FinishedGood";
                const bool lotCreation = false;
                const bool licensePlateCreation = true;
                var finishedGoodLineId = context.FinishedGoodLineIdByOrderAndFinishedGoodAndLot(Cmb_MfgOrder.Text, Cmb_FgLookupCode.Text, Cmb_LotLookupCode.Text).FirstOrDefault();
                var lotId = context.LotIdByManufacturingOrderAndFinishedGood(Cmb_MfgOrder.Text, Cmb_FgLookupCode.Text, Cmb_LotLookupCode.Text).FirstOrDefault();
                string lot = null;
                DateTime? lotManufactureDate = null;
                DateTime? lotExpirationDate = null;
                var packagedAmount = Convert.ToDecimal(Txt_PackagedAmount.Text);
                const int packagedId = 3;
                var licensePlateLookupCode = Txt_LicensePlateLookupCode.Text;
                int? licensePlateId = null;
                const int licensePlateLocationId = 51372;
                // Call SQL Server SPROC datex_footprint_integration.AddFeedbackRequestsAgentInsert and enter data to FootPrint Task
                var run = context.AddFeedbackRequestsAgentInsert(recordType, lotCreation, licensePlateCreation, finishedGoodLineId,
                    lotId, "", lotManufactureDate, lotExpirationDate, packagedAmount, packagedId, licensePlateLookupCode,
                    licensePlateId, licensePlateLocationId);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }       
        }
