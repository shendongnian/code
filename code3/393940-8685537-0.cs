    var dataSets = pRows.GroupJoin(cRows,
                                   p => p.Attribute(XId).Value,
                                   c => c.Attribute(XParentId).Value,
                                   (p, children) => new {
                                     ParentID = p.Attribute(XId).Value,
                                     Children = children.Select(c => c)
                                   });
