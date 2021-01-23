        [Test, Explicit]
        public void OracleDecimal_NarrowingConversion_ShouldSucceed()
        {
            string sigfigs = "-9236717.7113439267890123456789012345678";
            OracleDecimal od = new OracleDecimal(sigfigs);
            OracleDecimal narrowedOd = OracleDecimal.SetPrecision(od, 28); //fails
            //OracleDecimal narrowedOd = OracleDecimal.SetPrecision(od, 27); //succeeds
            object narrowedObjectValue = (object)narrowedOd.Value;
            Assert.IsInstanceOf<decimal>(narrowedObjectValue);
        }
