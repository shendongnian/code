    var formsWithChildren = subForms.GroupBy(s => s.Form.FormId)
                                    .Select(g => new Form
                                    {
                                        FormId = g.Key,
                                        SubForms = g.ToList()
                                    }).ToList();
