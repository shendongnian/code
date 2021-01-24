    static void Main(string[] args)
    {
        string string1 = ApplicationData.Current.LocalSettings.Values[@"param1"] as string;
        string string2 = ApplicationData.Current.LocalSettings.Values[@"param2"] as string;
        string string3 = ApplicationData.Current.LocalSettings.Values[@"param3"] as string;
        string string4 = ApplicationData.Current.LocalSettings.Values[@"param4"] as string;
    }
