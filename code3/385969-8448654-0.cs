    public static string ToUserFriendlyDateFormat(this string unfriendlyFormat) {
        return unfriendlyFormat
            .Replace("{0:", string.Empty)
            .Replace("}", string.Empty);
    }
