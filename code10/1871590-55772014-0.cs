    private static ISettings Settings => CrossSettings.Current;
    private static string PhoneNumberKey = "PhoneNumberKey";
    public static int PhoneNumber
    {
        get => Settings.GetValueOrDefault(nameof(PhoneNumberKey), 0);
        set => Settings.AddOrUpdateValue(nameof(PhoneNumberKey), value);
    }
}
