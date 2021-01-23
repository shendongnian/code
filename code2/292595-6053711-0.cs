	using (var inp = ...) {
		string line;
		while ((line = inp.ReadLine()) != null) {
            // normalize to our world of 8-space tabs                        
			line = line.Replace("\t", "        ");
			var lineDepth = line.Length - line.TrimStart().Length;
			if (lineDepth < 65) {
				// is potential "heading line"
			} else { // >= 65
				// is "property line"
			}
		}
	}
