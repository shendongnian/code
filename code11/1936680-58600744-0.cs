	void Main()
	{
		var rows = new List<Row> {
			new Row() { Col1 = 1, Col2 = null, Col3 = null},
			new Row() { Col1 = null, Col2 = 2, Col3 = null},
			new Row() { Col1 = null, Col2 = null, Col3 = 3},
			new Row() { Col1 = 2, Col2 = null, Col3 = null},
		};
		var flattened = rows.Flatten();
	}
	
	public static class MyExtensions
	{
		public static List<T> Flatten<T>(this List<T> list)
		{
			if (list == null || !list.Any() || list.Count() == 1 || list.First().GetType().GetProperties().Count() == 0)
			{
				return list;
			}
				
			var index = 0;
			var runner = 0;
			var result = new List<T>();
			do
			{
				result.Add(list[runner]);
	
				for (int r = runner + 1; r < list.Count; r++)
				{
					if (CanCollapse(result[index], list[r]))
					{
						Collapse(result[index], list[r]);
						runner++;
					}
					else
					{
						break;
					}
				}
				runner++;
				index++;
			} while (runner < list.Count());
			
			return result;
		}
			
		private static bool CanCollapse<T>(T target, T next)
		{
			foreach (var p in target.GetType().GetProperties())
			{
				var targetValue = p.GetValue(target, null);
				var nextValue = p.GetValue(next, null);
				
				if (targetValue != null && nextValue != null && !targetValue.Equals(nextValue))
				{
					return false;
				}
			}
			return true;		
		}
		
		private static void Collapse<T>(T target, T next)
		{
			foreach (var p in target.GetType().GetProperties())
			{
				var targetValue = p.GetValue(target, null);
				var nextValue = p.GetValue(next, null);
				
				if (nextValue != null && targetValue == null)
				{
					p.SetValue(target, nextValue);	
				}
			}
		}
	}
	
	public class Row
	{
		public int? Col1 { get; set; }
		public int? Col2 { get; set; }
		public int? Col3 { get; set; }
	}
