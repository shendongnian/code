        [Test]
        public void CheckThatAllEnumCoveredInSwitchCase()
        {
            
            foreach (var singleEnum in Enum.GetValues(typeof(YOURENUM)))
            {
                    myclass.methodofswitchcase((YOURENUM)singleEnum);
            }
            
        }
