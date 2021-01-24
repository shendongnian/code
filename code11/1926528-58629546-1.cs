    var repository = ViewModel.Products.FirstOrDefault(x => x.RepositoryName == repositoryName);
            var cachedFilename = MemoryCache.Get<string>(connectionId);
            if (button == "btn-config")
            {
                var testsFolderPath = repository != null ? repository.TestsFolderPath : "";
                var testsDirectory = GetTestsDirectory(repositoryName, branch, testsFolderPath);
                var configPath = GetConfigPath(repositoryName, branch);
            }
            else{
                var testsDirectory = repository != null ? repository.StepFilePath : "";
                var configPath = GetStepFile(repositoryName, branch, testsDirectory);
                var stepFile = GetStepFile(repositoryName, branch, testsDirectory);
               }
         string fullPath = string.empty;
            if (cachedFilename.Contains(filename) && Path.GetFileName(configPath) == filename)
            {
                fullPath = configPath;
               
            }
            else{
            fullPath = Path.Combine(testsDirectory, filename);
              }
            await IOHelper.WriteContentsToFileAsync(fullPath, fileContents);
            return Ok();
