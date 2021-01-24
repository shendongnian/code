	private static int FindIn( string text, string sub ) {
		if (string.IsNullOrWhiteSpace( text ) || string.IsNullOrWhiteSpace( sub ) ) {
			return string.IsNullOrWhiteSpace( sub ) ? 0 : -1;
		}
		if (text.Length < sub.Length) {
			return -1;
		}
		for (int i = 0; i < text.Length - sub.Length; i++) {
			if (text[i] != sub[0]) {
				continue;
			}
			var matched = true;
			for (int j = 1; j < sub.Length && i + j < text.Length; j++) {
				if (text[i+j] != sub[j]) {
					matched = false;
					break;
				}
			}
			if (matched) {
				return i;
			}
		}
		
		return -1;
	}
