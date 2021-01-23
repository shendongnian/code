    /// <summary>
    /// Performs a breadth-first traversal of a control's control tree. Unlike
    /// FindControl, this method does not descend into controls that have not
    /// called EnsureChildControls yet.
    /// </summary>
    /// <returns>Enumerable of the visited controls.</returns>
    public static IEnumerable<Control> GetControlDescendants(this Control parent) {
        // Don't force execution of EnsureChildControls
        if (!parent.HasControls()) yield break;
        foreach (Control child in parent.Controls) {
            yield return child;
        }
        foreach (Control child in parent.Controls) {
            foreach (var descendant in child.GetControlDescendants()) {
                yield return descendant;
            }
        }
    }
