    private static readonly string[] SupportedSchmes = { Uri.UriSchemeHttp, Uri.UriSchemeHttps, Uri.UriSchemeFtp, Uri.UriSchemeFile };
    private static bool TryCreateUri(string uriString, out Uri result)
    {
        return Uri.TryCreate(uriString, UriKind.Absolute, out result) && SupportedSchmes.Contains(result.Scheme);
    }
    private static bool TryCreateUri(Uri baseAddress, string relativeAddress, out Uri result)
    {
        return Uri.TryCreate(baseAddress, relativeAddress, out result) && SupportedSchmes.Contains(result.Scheme);
    }
