    List<string> nameOnly = original.ConvertAll(s => {
                                                         int i = s.IndexOf('\\');
                                                         return (i < 1) 
                                                             ? s
                                                             : s.Substring(0, i);
                                                     });
