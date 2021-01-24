public void RunStarted(
    Object automationObject, Dictionary<String, String> replacementsDictionary, WizardRunKind runKind, Object[] customParams)
{
    DTE dte = automationObject as DTE;
    
    String destinationDirectory = replacementsDictionary["$destinationdirectory$"];
    
    try
    {
        using (PackageDefinition definition = new PackageDefinition(dte, destinationDirectory))
        {
            DialogResult dialogResult = definition.ShowDialog();
    
            if (dialogResult != DialogResult.OK)
            {
                throw new WizardBackoutException();
            }
    
            replacementsDictionary.Add("$packagePath$", definition.PackagePath);
            replacementsDictionary.Add("$packageExtension$", Path.GetExtension(definition.PackagePath));
    
            _dependentProjectName = definition.SelectedProject;
        }
    }
    catch (Exception ex)
    {
        // Clean up the template that was written to disk
        if (Directory.Exists(destinationDirectory))
        {
            Directory.Delete(destinationDirectory, true);
        }
    
        Debug.WriteLine(ex);
    
        throw;
    }
}
