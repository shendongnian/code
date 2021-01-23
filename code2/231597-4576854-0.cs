	var list1Dicts=names1.GroupBy(i=>i).ToDictionary(g=>g.Key,g=>g.Count());
	var list2Dicts=names2.GroupBy(i=>i).ToDictionary(g=>g.Key,g=>g.Count());
    return
		list1Dicts.Count == list2Dicts.Count
		&& list1Dicts.All(kv => {
            int count2; 
            return list2Dicts.TryGetValue(kv.Key,out count2) && count2==kv.Value;
        });
