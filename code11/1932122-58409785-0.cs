        /// <summary>
        /// Test to Get the all the fee bands from Crm
        /// </summary>
        /// <returns>Response with a collection of ise_feeband entities</returns>
        [TestCategory("AnnualBillingService")]
        [TestMethod]
        public void GetFeeBandingListTest()
        {
            Guid ID = new Guid();
            List<ISE_feeband> fee_bands = new List<ISE_feeband>();
                             
            using (ShimsContext.Create())
            {
                //Arrange
                ShimCrmService.AllInstances.FetchString = ((@this, fetchXml) =>
                {
                    var output = new Microsoft.Xrm.Sdk.EntityCollection()
                    {
                        EntityName = ISE_feeband.EntityLogicalName,
                    };
                    output.Entities.Add(new ISE_feeband()
                    {
                        Id = ID,                        
                    });
                    return output;
                });
                //Act              
                var AnnualBillingService = new AnnualBillingService();
                var response = AnnualBillingService.GetFeeBandingList();
                //Assert
                Assert.IsNotNull(response, "Expected not-null response");
                Assert.IsTrue(response.FeeBands.Count == 1, "Expected: " + fee_bands + " but found " + response.FeeBands);
                foreach (var FeeBands in fee_bands)
                {
                    Assert.IsTrue(FeeBands.ISE_feebandId == ID , "Expects True");
                }
            }
        }
Problem solved guys THANK YOU all :)
