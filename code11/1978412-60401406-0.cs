        private void PrintSeatsDetails(List<Seat> _seats)
        {
            //sorting by row because you don't know that the order of the seats are set
            _seats.Sort((a, b) => (a.Row.CompareTo(b.Row)));
            int curRow = -1;
            foreach (var item in _seats)
            {
                if (item.Row != curRow) {
                    curRow = item.Row;
                    Console.Write($"\nRow: {curRow}. ");
                }
                Console.Write($"Col: {item.Col}:{item.Status}. ");
            }
        }
