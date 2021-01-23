      internal static string ToString(Ancestor root){
            Func<Parent, string, string> inner = (x, y) => string.Empty;
            Expression<Func<Parent, string, string>>
                innerExperssion = (parent, indentation) =>
                                  (from p in new[]{parent}
                                   let parents = p.Children.OfType<Parent>()
                                   let children = p.Children.OfType<Child>()
                                   let childString =
                                       string.Concat
                                       (children.Select
                                            (c => indentation + "-" + c.Name + Environment.NewLine))
                                   select indentation + "-" + parent.Name + Environment.NewLine +
                                          childString +
                                          string.Concat
                                              (parents.Select(par => inner(par, " " + indentation))))
                                      .First();
            inner = innerExperssion.Compile();
            return inner(root, string.Empty);
        }
