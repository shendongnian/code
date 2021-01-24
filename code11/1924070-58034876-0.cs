    public static bool Security(string userID, string action, string details )
    {
        // Other code omitted for brevity
        var strDetails = $"{details} ";
    }
    public static bool Security(string userID, string action, string[] details )
    {
        // Other code omitted for brevity
            
        var strDetails = string.Join(Environment.NewLine,
            details.Select((detail, index) => $"Detail {index + 1}: {detail}"));
    }
