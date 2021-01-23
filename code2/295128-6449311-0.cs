        [Test]
        public void Folder_GetPropertyType_Valid()
        {
            using (var folder = IntegrationUtil.GetFolder())
            {
                PropId pid = folder.Properties.ElementAt(FolderMockConstants.FOLDER_FIRST_ELEMENT);
                Assert.AreEqual(FolderMockConstants.FOLDER_VALID_PROPERTY_TYPE, folder.GetPropertyType(pid));
            }
        }
