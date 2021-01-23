    	public static string FindDuplicateSubstring(string s, 
                                                    bool allowOverlap = false)
		{
			int matchPos = 0, maxLength = 0;
			for (int shift = 1; shift < s.Length; shift++) {
				int matchCount = 0;
				for (int i = 0; i < s.Length - shift; i++) {
					if (s[i] == s[i+shift]) {
						matchCount++;
						if (matchCount > maxLength) {
							maxLength = matchCount;
							matchPos = i-matchCount+1;
						}
						if (!allowOverlap && (matchCount == shift)) {
							// we have found the largest allowable match 
                            // for this shift.
							break;
						}
					} else matchCount = 0;
				}
			}
			if (maxLength > 0) return s.Substring(matchPos, maxLength);
			else return null;
		}
