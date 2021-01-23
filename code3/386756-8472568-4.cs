        internal string ToString(Ancestor parent, string indentation){
            var parents = parent.Children.OfType<Parent>();
            var children = parent.Children.OfType<Child>();
            var childString = children.Select(c => indentation + "-" + c.Name + Environment.NewLine);
            return indentation + "-" + parent.Name + Environment.NewLine + childString +
                   string.Concat(parents.Select(par => ToString(par, " " + indentation)));
        }
