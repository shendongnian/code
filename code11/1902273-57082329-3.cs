    public static string AddMidSubString(this string Str, string MidSubString)
    {
        if (StringExtensionSettings.Instance.AddMidSubString)
        {
            StringBuilder Result = new StringBuilder(Str);
            Result.Insert(Result.Length / 2, MidSubString);
            return Result.ToString();
        }
        throw new Exception($"Not allowed to call {nameof(AddMidSubString)}");
    }
