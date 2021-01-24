    _context.GameHasPlayers.Join(
        _context.Games,
        gameHasPlayer => GameHasPlayer.GameId,
        game => Game.Id,
        (gameHasPlayer, game) => new { GameHasPlayer = gameHasPlayer, Game = game }
    )
    from ghp in _context.GameHasPlayers
    join g in _context.Games on g.Id equals ghp.GameId
    select new { GameHasPlayer = ghp, Game = g }
