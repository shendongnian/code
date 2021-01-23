C#
public static string RemoveExtension(this string file) => ReplaceExtension(file, null);
public static string ReplaceExtension(this string file, string extension)
{
    var split = file.Split('.');
    if (string.IsNullOrEmpty(extension))
        return string.Join(".", split[..^1]);
    split[^1] = extension;
    return string.Join(".", split);
}
