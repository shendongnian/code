    loadTic.Completed += (s, a) =>
        {
            List<int> takenSeats = new List<int>();
            foreach (Web.Ticket ticket in  ((LoadOperation<Web.Ticket>)s).Entities.ToList())
            {
                takenSeats.Add((int)ticket.seatId);
                MessageBox.Show(ticket.seatId.ToString());
            }
        };
