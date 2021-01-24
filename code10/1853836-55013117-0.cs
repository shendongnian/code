	public class Program {
		[Benchmark]
		public void MyAnswer() {
			long machineId = 0;
			long employeeId = 0;
			var description = "machineId: 276744, engineId: 59440, employeeId: 4619825";
			var entryEnumerator = description.AsSpan().Split(',');
			while (entryEnumerator.MoveNext()) {
				var entry = entryEnumerator.Current;
				var keyValueEnumerator = entry.Split(':');
				keyValueEnumerator.MoveNext();
				var key = keyValueEnumerator.Current.TrimStart(' ');
				keyValueEnumerator.MoveNext();
				var value = keyValueEnumerator.Current.TrimStart(' ');
				if (key.Equals("machineId", StringComparison.OrdinalIgnoreCase)) {
					long.TryParse(value, out machineId);
				}
				if (key.Equals("employeeId", StringComparison.OrdinalIgnoreCase)) {
					long.TryParse(value, out employeeId);
				}
			}
		}
    }
	public static class Extensions {
		public static SpanSplitEnumerator Split(this ReadOnlySpan<char> span, char separator) {
			return new SpanSplitEnumerator(span, separator);
		}
		public ref struct SpanSplitEnumerator {
			private readonly char separator;
			private int pos;
			private ReadOnlySpan<char> span;
			public SpanSplitEnumerator(ReadOnlySpan<char> span, char separator) {
				this.separator = separator;
				this.pos = 0;
				this.span = span;
				this.Current = span;
			}
			public bool MoveNext() {
				if (pos == -1) return false;
				int nextpos = span.IndexOf(separator);
				if (nextpos == -1) {
					pos = nextpos;
					Current = span;
					return true;
				}
				Current = span.Slice(0, nextpos);
				span = span.Slice(nextpos + 1);
				pos = 0;
				return true;
			}
			public ReadOnlySpan<char> Current { get; private set; }
		}
	}
