    private static bool IsFirstElementNullOrEmpty(List<string> elements) {
        if (elements == null)
            throw new ArgumentNullException("elements");
     
        if (elements.Count > 0) {
            if (string.IsNullOrEmpty(elements[0])) {
                return true;
            }
        }
        return false;
    }
