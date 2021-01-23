        private void UnsetReadOnlyAttribute(string filePathWithName)
        {
            FileInfo fileInfo = new FileInfo(filePathWithName);
            if (fileInfo.IsReadOnly)
            {
                fileInfo.IsReadOnly = false;
            }
        }
