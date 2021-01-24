    private void Button_Click(object sender, RoutedEventArgs e)
            {
                var selectedSeats = selectSeatsViewModel.TopSeatList.SelectMany(x => x.Where(y => y.IsSelected));
                string selectedSeatNumbers = string.Empty;
                foreach(var seat in selectedSeats)
                {
                    selectedSeatNumbers += seat.SeatNumber + "";
                }
    
                SelectedSeatNumbersTextBlock.Text = selectedSeatNumbers;
            }
