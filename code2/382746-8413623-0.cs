    Masters
    	.Join(
    		States, 
    		master => master.Idstate, 
    		state => state.Idstate,
    		(master,state) => new
    			{
    				idmaster = master.Idmaster,
    				idstate = state.Idstate,
    				descr = state.Descr
    			}
    		)
    	.Join(
    		Groups,
    		firstJoin => firstJoin.idmaster,
    		groups=>groups.Idmaster,
    		(firstJoin, groups) => new
    			{
    				masterid = firstJoin.idmaster,
    				stateid = firstJoin.idstate,
    				groupid = groups.Idgroup,
    				descr = firstJoin.descr
    			}
    		)
    	.Where(x => new int?[]{1,2,3,4,5}.ToList().Contains(x.groupid))
    	.Where(x => new int?[]{1,2}.ToList().Contains(x.stateid))
