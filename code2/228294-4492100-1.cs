    private void SetProjectFolder(string sessionid)
        {
            //This will simulate the contains statement
            string searchPattern = string.Format("*{0}*", sessionid);
            string[] supportDirs = Directory.GetDirectories(ApplicationContainer.SupportDirectory, searchPattern);
            
            foreach (string filteredFolder in supportDirs)
            {
                _productName = Directory.GetParent(filteredFolder).Name;
                break;
            }
        }
