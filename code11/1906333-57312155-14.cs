    private static bool ContainsValue(List<string> elements, string elementToBeFound) {
        if (elements == null)
            throw new ArgumentNullException("elements");
     
        if (elements.Count > 0) {
            for (int count = 0; count < elements.Count; count++) {
                if (elements[count].Equals(elementToBeFound)) {
                    return true;
                }
            }
        }
        return false;
    }
