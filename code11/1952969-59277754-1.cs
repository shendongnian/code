csharp
using (var stream = await file.OpenStreamForReadAsync())
{
    stream.Position = 0;
    result = hash.ComputeHash(stream);
}
StringBuilder sb = new StringBuilder(result.Length * 2);
foreach (byte b in result)
{
    sb.AppendFormat("{0:x2}", b);
}
return sb.ToString();
Best regards.
