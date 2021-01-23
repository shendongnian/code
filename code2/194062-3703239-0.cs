    try {
         ....
    } catch (InvalidOperationException eInvalidOperationException) {
		if (eInvalidOperationException.TargetSite.DeclaringType == typeof(System.Diagnostics.Process)) {
			// Exception when accessing mWindowProcess
		} else
			throw;
	} catch (ArgumentException eArgumentException) {
		if (eArgumentException.TargetSite.DeclaringType == typeof(System.Diagnostics.Process)) {
			// Exception when accessing mWindowProcess
		} else
			throw;
	}
