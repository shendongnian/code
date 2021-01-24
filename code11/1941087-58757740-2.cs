    var boards = context.Boards
       .Where(b => b.Lists
          .Any(bl => bl.Cards.Any(c => c.CardType == CardTypes.Type1)))
       .Select(b => new BoardDTO
       {
          BoardId = b.BoardId,
          Name = b.Name,
          Lists = b.Lists.Select(bl => new BoardListDTO
          {
             BoardListId = bl.BoardListId,
             Name = bl.Name,
             Cards = bl.Cards.Where(c => c.CardType == CardTypes.Type1)
                .Select(c => new CardDTO
                {
                   CardId = c.CardId,
                   CardType = c.CardType
                }).ToList()
          }).ToList()
       }).ToList()
