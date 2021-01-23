        [Test, TestCaseSource("GetTestCases")]
        public void GetProductDetailsTest(Database1DataSet.GetProductDetailsTestRow dr)
        {
            if (pm.GetProductById(dr.productId) == null)
                Assert.Fail("Id of test case: " + dr.id + ", Product id of failure: " + dr.productId);
            }
        }
