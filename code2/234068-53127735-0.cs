            private static IEnumerable<T> GetControlsOfType<T>(this Control root)
            where T : Control
        {
            if (root is T t)
                yield return t;
            if (root is ContainerControl || root is Control)
            {
                var container = root as Control;
                foreach (Control c in container.Controls)
                    foreach (var i in GetControlsOfType<T>(c))
                        yield return i;
            }
        }
