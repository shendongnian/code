    var formName = String.Format("Form_{0}_BA", name);
    var candidate = typeof(FormBA).Assembly
                                  .GetTypes()
                                  .Single(tt => tt.IsSubclassOf(typeof(FormBA))
                                             && tt.Name.EndsWith(formName));
    var method = candidate.GetMethods(BindingFlags.Static | BindingFlags.Public)
                          .Single(mi => mi.GetParameters()
                                          .Single()
                                          .ParameterType == candidate);
