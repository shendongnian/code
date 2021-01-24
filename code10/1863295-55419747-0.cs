    public static class TempDataExtension
    {
        public static string GetErrorMessage(this ITempDataDictionary @this) =>
            @this["ErrorMessage"].ToString();
    }
