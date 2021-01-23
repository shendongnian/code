      internal static string ToString(Ancestor root){
            Func<Parent, string, string> inner = (x, y) => string.Empty;
            inner = (p, indentation) =>{
                        var parents = p.Children.OfType<Parent>();
                        var children = p.Children.OfType<Child>();
                        var childString =
                            string.Concat
                                (children.Select
                                     (c => indentation + "-" + c.Name + Environment.NewLine));
                        return indentation + "-" + p.Name + Environment.NewLine +
                               childString +
                               string.Concat
                                   (parents.Select(par => inner(par, " " + indentation)));
                    };
            return inner(root, string.Empty);
        }
