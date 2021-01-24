    static void saveIcons(List<IconDefinition> icons)
    {
        using (Stream stream = new FileStream(@".\icons.bin", FileMode.Create, FileAccess.Read))
            new BinaryFormatter().Serialize(stream, icons);
    }
    static List<IconDefinition> loadIcons()
    {
        using (Stream stream = new FileStream(@".\icons.bin", FileMode.Open, FileAccess.Read))
            return (List<IconDefinition>)new BinaryFormatter().Deserialize(stream);
    }
