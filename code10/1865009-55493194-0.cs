 c#
using (var target = File.Create(path))
using (var source = httpResponse.GetResponseStream())
{
    source.CopyTo(target);
}
