    public static IEnumerable<T> FindAllControlsOfType<T>(Control parent) where T : Control
    {
        if (parent != null)
        {
            foreach (var control in parent.Controls)
            {
                 if (control is T)
                 {
                     yield return (T)control;
                 }
                 foreach (var childOfChild in FindAllControlsOfType<T>(control as Control))
                 {
                     yield return childOfChild;
                 }
            }
        }
    }
