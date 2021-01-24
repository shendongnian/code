	public class Program {
		public void MyAnswer() {
			long machineId = 0;
			long employeeId = 0;
			var description = "machineId: 276744, engineId: 59440, employeeId: 4619825";
			var span = description.AsSpan();
			while (span.Length > 0) {
				var entry = span.SplitNext(',');
				var key = entry.SplitNext(':').TrimStart(' ');
				var value = entry.TrimStart(' ');
				if (key.Equals("machineId", StringComparison.Ordinal)) {
					long.TryParse(value, out machineId);
				}
				if (key.Equals("employeeId", StringComparison.Ordinal)) {
					long.TryParse(value, out employeeId);
				}
			}
		}
    }
	public static class Extensions {
		public static ReadOnlySpan<char> SplitNext(this ref ReadOnlySpan<char> span, char seperator) {
			int pos = span.IndexOf(seperator);
			if (pos > -1) {
				var part = span.Slice(0, pos);
				span = span.Slice(pos + 1);
				return part;
			} else {
				var part = span;
				span = span.Slice(span.Length);
				return part;
			}
		}
	}
