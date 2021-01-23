    List<string[]> moves = new List<string[]>();
    string[] newmove = { piece, axis.ToString(), direction.ToString() };
    moves.Add(newmove);
    moves.Add(newmove);
    moves = moves.Distinct().ToList();
    // At this stage moves.Count = 1
