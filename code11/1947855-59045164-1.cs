    var res = _context.GameHasPlayers
        .Where(x => x.PlayerId == playerId)
        .Join(_context.Games,
                ghp => ghp.GameId,
                g => g.Id,
                (gameHasPlayer, game) => new Game { }
            );
