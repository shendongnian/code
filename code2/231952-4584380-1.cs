public void Save(string xmlFilePath)
{
    Thread thread = new Thread(new ParameterizedThreadStart(SaveSettings));
    thread.Start(xmlFilePath);
}
private void SaveSettings(object data)
{
    string xmlFilePath;
    if ((xmlFilePath = data as string) != null)
    {
        this.SaveSettingsFile(xmlFilePath);
    }
}
private void SaveSettingsFile(string xmlFilePath)
{ 
    // Save the file contents
}
