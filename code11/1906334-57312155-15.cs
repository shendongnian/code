    private static bool ContainsDuplicate(List<string> elements) {
        if (elements == null)
            throw new ArgumentNullException("elements");
     
        if (elements.Count > 0) {
            for (int count = 0; count < elements.Count; count++) {
                for (int innerCount = 0; innerCount < elements.Count; innerCount++) {
                    if (count == innerCount) {
                        continue;
                    }
                    if (elements[count].Equals(elements[innerCount])) {
                        return true;
                    }
                }
            }
        }
        return false;
    }
