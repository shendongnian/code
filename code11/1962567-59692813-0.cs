    var result = db.CafeTables.Where(c => c.TableNo == userName)
                             .Join(db.CafeTableDetails.GroupBy(x=>x.CafeTableId)
                             .Select(g => new { CafeTableId = g.Key, cnt = g.Count() }), 
    st => st.Id,
    cd => cd.CafeTableId,
    (st,cd) => new  
    {
    	st.Id,
    	cd.cnt
    	//..... your expect property
    });
