    var x = _context.GameHasPlayers
        .Where(x.PlayerId == playerId)
        .Join(_context.Games,
                x => ghp.GameId,
                x => g.Id,
                (gameHasPlayer, game) => new Game { }
            );
