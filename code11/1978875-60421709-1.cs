        public void ThenICanSeeTheFunctionlitiesForNONtransitionUserAsClnician()
            {
            Assert.Multiple(() =>
                {
              Assert.IsTrue(ObjectRepository.phPage.GetMenuList().Contains("Show menu"));
              Assert.IsTrue(ObjectRepository.phPage.GetMenuList().Contains("Patient Summary"));
            Assert.IsTrue(ObjectRepository.phPage.GetMenuList().Contains("Patient Encounter"));
                });
        }
