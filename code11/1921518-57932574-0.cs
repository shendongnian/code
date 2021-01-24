	public static IEnumerable<TResult> FullOuterJoin<TA, TB, TKey, TResult>(
		this IEnumerable<TA> a,
		IEnumerable<TB> b,
		Func<TA, TKey> selectKeyA,
		Func<TB, TKey> selectKeyB,
		Func<TA, TB, TKey, TResult> projection,
		TA defaultA = default(TA),
		TB defaultB = default(TB),
		IEqualityComparer<TKey> cmp = null)
	{
		cmp = cmp ?? EqualityComparer<TKey>.Default;
		var alookup = a.ToLookup(selectKeyA, cmp);
		var blookup = b.ToLookup(selectKeyB, cmp);
		var keys = new HashSet<TKey>(alookup.Select(p => p.Key), cmp);
		keys.UnionWith(blookup.Select(p => p.Key));
		var join = from key in keys
				   from xa in alookup[key].DefaultIfEmpty(defaultA)
				   from xb in blookup[key].DefaultIfEmpty(defaultB)
				   select projection(xa, xb, key);
		return join;
	}
    Enumerable<System.IO.FileInfo> filesA = dirA.GetFiles(".", System.IO.SearchOption.AllDirectories); 
    IEnumerable<System.IO.FileInfo> filesB = dirB.GetFiles(".", System.IO.SearchOption.AllDirectories); 
    var files = filesA.FullOuterJoin(
        filesB,
        f => $"{f.FullName.Replace(dirA.FullName, string.Empty)}|{f.Length}",
        f => $"{f.FullName.Replace(dirB.FullName, string.Empty)}|{f.Length}",
        (fa, fb, n) => new {fa, fb, n}
    );
    var filesOnlyInA = files.Where(p => p.fb == null);
    var filesOnlyInB = files.Where(p => p.fa == null);
    var matchingFiles = files.Where(p => p.fa != null && p.fb != null);
    //   Iterate and copy/delete as appropriate
      
