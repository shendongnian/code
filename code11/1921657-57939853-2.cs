	Console.WriteLine ("Times in seconds per 10m merged/sliced operations");
	foreach (var init in new[] { "empty", "size", "spare" }) {
		for (int n = 10 * 1000 * 1000; n <= 40 * 1000 * 1000; n += 10 * 1000 * 1000) {
			for (int repeat = 0; repeat < 3; repeat++) {
				Stopwatch wmi, wml, wsi, wsl;
				{
					GC.Collect ();
					var r = new Random (0);
					Dictionary<int, object> d;
					if (init == "empty") {
						d = new Dictionary<int, object> ();
					}
					else if (init == "size") {
						d = new Dictionary<int, object> (n);
					}
					else {
						d = new Dictionary<int, object> (2 * n);
					}
					wmi = Stopwatch.StartNew ();
					for (int i = 0; i < n; i++) {
						var key = r.Next ();
						d[key] = null;
					}
					wmi.Stop ();
					wml = Stopwatch.StartNew ();
					var dummy = false;
					for (int i = 0; i < n; i++) {
						dummy ^= d.ContainsKey (i);
					}
					wml.Stop ();
				}
				{
					GC.Collect ();
					var r = new Random (0);
					var ds = new Dictionary<int, object>[256];
					for (int i = 0; i < 256; i++) {
						if (init == "empty") {
							ds[i] = new Dictionary<int, object> ();
						}
						else if (init == "size") {
							ds[i] = new Dictionary<int, object> (n / 256);
						}
						else {
							ds[i] = new Dictionary<int, object> (2 * n / 256);
						}
					}
					wsi = Stopwatch.StartNew ();
					for (int i = 0; i < n; i++) {
						var key = r.Next ();
						var d = unchecked(ds[key & 0xFF]);
						d[key] = null;
					}
					wsi.Stop ();
					wsl = Stopwatch.StartNew ();
					var dummy = false;
					for (int i = 0; i < n; i++) {
						var d = unchecked(ds[i & 0xFF]);
						dummy ^= d.ContainsKey (i);
					}
					wsl.Stop ();
				}
				string perM (Stopwatch w) => $"{w.Elapsed.TotalSeconds / n * 10 * 1000 * 1000,5:0.00}";
				Console.WriteLine ($"init = {init,-5}, n = {n,8};"
					+ $" insert = {perM (wmi)}/{perM (wsi)},"
					+ $" lookup = {perM (wml)}/{perM (wsl)}");
			}
		}
		Console.WriteLine ();
	}
