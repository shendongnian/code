    private List<Seat> _Seats = new List<Seat>();
    public Form1() {
      InitializeComponent();
      _Seats.Add(new Seat("1a", new Rectangle(10, 10, 10, 10)));
      _Seats.Add(new Seat("2b", new Rectangle(20, 20, 10, 10)));
    }
    private void Form1_Paint(object sender, PaintEventArgs e) {
      foreach (Seat seat in _Seats)
        e.Graphics.FillRectangle(Brushes.Red, seat.SeatRectangle);
    }
    private void Form1_MouseDown(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) {
        foreach (Seat seat in _Seats) {
          if (seat.SeatRectangle.Contains(e.Location))
            MessageBox.Show("Clicked on seat " + seat.SeatKey);
        }
      }
    }
