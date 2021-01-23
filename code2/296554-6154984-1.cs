    			var graph = new Graph
			{
				cols = new ColInfo[] {
					new ColInfo { id = "A", label = "set A", type = "string" },
					new ColInfo { id = "B", label = "set B", type = "string" },
					new ColInfo { id = "C", label = "set C", type = "string" }
				},
				rows = new DataPointSet[] {
					new DataPointSet { c = new DataPoint[] {
						new DataPoint { v = "a" },
						new DataPoint { v = "b", f = "One" },
					} }
				},
				p = new Dictionary<string, string>()
			};
			string json;
			var s = new JsonSerializer();
			using (var sw = new StringWriter()) {
				s.Serialize(sw, graph);
				json = sw.ToString();
			}
