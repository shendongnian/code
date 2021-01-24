    <ul>
        @foreach (var booking in Bookings)
        {
            <li>@booking.BookedRoomNumber</li>
        }
    </ul>
    
    @functions{
    
    var timer = new Timer(new TimerCallback(_ =>
            {
                // Code to fetch the data and bind it to the page level variable
                // Ex : Bookings = GetBookingsData();
    
                // This line is necessary
                this.StateHasChanged();
            }), null, 1000, 1000);
    
    }
