    // This is the method test thati use it for xml, and i want do the same for a pdf 
    [TestMethod]
        public void EvolisPrinterCanPrintMockup()
        {
            var jobTemplate = new MockupJobTemplate(
                () => XElement.Parse(Resources.Carte_ABO_L1_18_19_SMC),
                "TEST Print XML");
            IPrinter printer = EvolisPrinter.Create(new EvolisPrinterConfiguration
            {
                Name = TestPrinterName,
                Landscape = true
            }, new PcScSharpSmartCardService());
            var job = printer.CreateJob(jobTemplate);
            job.ReadChipUid = true;
            var uid = (string)job.Print();
            Assert.IsNotNull(uid);
        }
