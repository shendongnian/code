 var x = from ghp in _context.GameHasPlayers
         join g in _context.Games
         on new
         {
             playerId = ghp.PlayerId,
             gameId = ghp.GameId
         } equals new
         {
             playerId,
             gameId = g.Id
         }
         select new Game{ };
So you may rewrite this query as:
var x = _context.GameHasPlayers.Join(_context.Games, e => new { playerId = e.PlayerId, gameId = e.GameId }, y => new { playerId, gameId = y.Id }, (e, y) => new Game{ });
The both query will be translated into the same sql query. 
