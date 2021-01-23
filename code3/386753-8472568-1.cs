       private static Func<Parent, string, string> inner;
        internal static string ToString(Ancestor root){
            inner = (parent, indentation) =>{
                        var parents = parent.Children.OfType<Parent>();
                        var children = parent.Children.OfType<Child>();
                        var childString = string.Concat
                            (children.Select
                                 (c => indentation + "-" + c.Name + Environment.NewLine));
                        return indentation + "-" + parent.Name + Environment.NewLine +
                               childString +
                               string.Concat
                                   (parents.Select(par => inner(par, " " + indentation)));
                    };
            return inner(root, string.Empty);
        }
