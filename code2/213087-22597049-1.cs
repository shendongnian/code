    [DllImport("IconChanger.dll")]
    static extern void ChangeIcon(String executableFile, String iconFile, short imageCount);
    /// <summary>
    /// Changes the executable's icon
    /// </summary>
    /// <param name="exeFilePath">Path to executable file</param>
    /// <param name="iconFilePath">Path to icon file</param>
    static public void ChangeIcon(string exeFilePath, string iconFilePath)
    {
        short imageCount = 0;
        using (StreamReader sReader = new StreamReader(iconFilePath))
        {
            using (BinaryReader bReader = new BinaryReader(sReader.BaseStream))
            {
                // Retrieve icon count inside icon file
                bReader.ReadInt16();
                bReader.ReadInt16();
                imageCount = bReader.ReadInt16();
            }
        }
        // Change the executable's icon
        ChangeIcon(exeFilePath, iconFilePath, imageCount);
    }
