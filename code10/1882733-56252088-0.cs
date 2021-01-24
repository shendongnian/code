/// &lt;summary&lt;
/// Writes to the <see cref="Stream"/> using the supplied <see cref="Encoding"/>.
/// <b>It does not write the BOM and also does not close the stream.</b>
/// &lt;/summary&lt;
public class HttpResponseStreamWriter : TextWriter
{
    private const int MinBufferSize = 128;
    internal const int DefaultBufferSize = 16 * 1024;
    ...
}
