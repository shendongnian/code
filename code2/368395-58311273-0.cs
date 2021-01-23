public enum Prefix
{
    [Description("doctor")]
    doctor = 1,
    [Description("mr")]
    mr = 2,
    [Description("mrs")]
    mrs = 3
}
public static class PrefixAdapter {
    public static string ToText(this Prefix prefix) {
        return prefix.GetEnumDescription();
    }
    public static Prefix ToPrefix(this string text) {
        switch (text)
        {
            case "doctor"
                return Prefix.doctor;
            case "mr"
                return Prefix.mr;
            case "ms"
                return Prefix.mrs;
        }
    }
}
