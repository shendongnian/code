    using System.Linq;
    ...
    private void Start()
    {
        ImageByString = word.Zip(vp, (k, v) => new {k, v}).ToDictionary(x => x.k, x => x.v);
    }
