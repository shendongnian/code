        public static IEnumerable<Visual> ToVisualTree(this Visual visual)
        {
            yield return visual;
            int numVisuals = VisualTreeHelper.GetChildrenCount(visual);
            for (int i = 0; i < numVisuals; ++i)
            {
                var child = (Visual)VisualTreeHelper.GetChild(visual, i);
                if (child == null) yield break;
                
                foreach (var subItem in child.ToVisualTree())
                {
                    yield return subItem;
                }                
            }
        }
