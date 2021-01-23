var data = MemoryMappedFile.CreateNew("big data", 12000L * 55000L);
var view = data.CreateViewAccessor();
var rnd = new Random();
for (var i = 0L; i &lt; 12000L; ++i)
{
    for (var j = 0L; j &lt; 55000L; ++j)
    {
        var input = rnd.NextDouble();
        view.Write&lt;double&gt;(i * 55000L + j, ref input);
    }
}
