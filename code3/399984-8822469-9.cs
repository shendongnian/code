    class MoveIterator : IEnumerable<Move>
    {
        public IEnumerator<Move> GetEnumerator()
        {
            foreach(Move move in MoveTower(whatever))
                yield return move;
        }
