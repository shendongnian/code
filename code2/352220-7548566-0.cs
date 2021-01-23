    (from g in _context.Games.Include(pg => pg.PreviousGame.GameObjects.Select(o => o.Object.Video))
    	.Include(go => go.GameObjects.Select(o => o.Object.Video))
    where EntityFunctions.DiffMilliseconds(DateTime.Now, g.EndDate) > 0
    	&& g.GameTypeId == (int)GameTypes.Lottery
    	&& g.GameStatusId == (int)GameStatues.Open
    select g).FirstOrDefault();
