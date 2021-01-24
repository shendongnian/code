C#
void Main()
{
    DataTable dt = new DataTable();
	
	DateTime start = DateTime.Now;
	
	Random _rand = new Random();
	List<int> result = Enumerable.Range(1, 6000)
	.Select(x => x++)
	.ToList();
	result.AsParallel<int>().ForAll(c =>
	{
		Util.GetFromCache("datatable", c);
		System.Threading.Thread.Sleep(1);
	});
	
	DateTime.Now.Subtract(start).Seconds.Dump();
	"....DONE.....".Dump();
}
public static class Util
{
	private static readonly object _Lock = new object();
	public static object GetFromCache(string cachename, int i)
	{
		object obj = MemoryCacher.GetValue(cachename);
//		if (i == 5) //when time is up - reset token, update DB and add to cache es example i set a count=5
//		{
//			obj = null;
//			MemoryCacher.Delete(cachename);
//		}
		if (obj == null)
		{
			lock (_Lock)
			{
				obj = MemoryCacher.GetValue(cachename);
				if (obj == null)
				{
					$"{i} from DATA".Dump();
					obj = GetData();
					MemoryCacher.Delete(cachename);
					MemoryCacher.Add(cachename, obj, DateTimeOffset.Now.AddSeconds(5));
					return obj;
				}
				$"{i} from CACHE with lock".Dump();
			}
		}
		$"{i} from CACHE".Dump();
		return obj;
	}
	public static DataTable GetData()
	{
		DataTable dt = new DataTable();
		FileInfo fi = new FileInfo("c:\\1\\text.txt");
		dt = CSVtoDS(fi.FullName, true).AsEnumerable().Take(10).CopyToDataTable();
		return dt.Dump("call");
	}
	public static DataTable CSVtoDS(string filePath, bool isFirstLineHeader)
	{
		DataTable dt = new DataTable();
		using (TextReader tr = File.OpenText(filePath))
		{
			string strRow = string.Empty;
			string[] arrColumns = null;
			int indx = 0;
			while ((strRow = tr.ReadLine()) != null)
			{
				//set up columns
				if (indx == 0)
				{
					arrColumns = strRow.Split('\t')[0].Split(',').Select(x => x.Replace(" ", "_")).ToArray();
					if (dt.Columns.Count != arrColumns.Length + 1)
						for (int i = 0; i <= arrColumns.Length - 1; i++)
						{
							if (isFirstLineHeader)
								dt.Columns.Add(new DataColumn(arrColumns[i]));
							else
								dt.Columns.Add(new DataColumn());
						}
					indx = 1;
				}
				else
				{
					DataRow dr = dt.NewRow();
					dr.ItemArray = strRow.Split(',');
					dt.Rows.Add(dr);
				}
			}
			tr.Close();
		}
		return dt;
	}
	public static class MemoryCacher
	{
		public static object GetValue(string key)
		{
			MemoryCache memoryCache = MemoryCache.Default;
			return memoryCache.Get(key);
		}
		public static void Add(string key, object value, DateTimeOffset absExpiration)
		{
			MemoryCache memoryCache = MemoryCache.Default;
			memoryCache.Set(key, value, absExpiration);
		}
		public static void Delete(string key)
		{
			MemoryCache memoryCache = MemoryCache.Default;
			if (memoryCache.Contains(key))
			{
				memoryCache.Remove(key);
			}
		}
	}
}
