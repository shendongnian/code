    var listsByCb = new Dictionary<CheckBox, MyListType>
                    {{ aListBox, aList}, {bListBox, bList}, {cListBox, cList}};
    
    var segmentList = listsByCb.Where(kvp => kvp.Key.Checked)
                               .SelectMany(kvp => kvp.Value.Cast<BaseSegment>())
                               .Distinct();
                               .OrderBy(item => item.SegSeqNumber)
                               .ToList();
