        public ActionResult Create() {
            BookingVM VM = new BookingVM();
            VM.Initiate();
            VM.Booking.Transdate = DateTime.Today.Date;
            return View(VM);
        }
        [HttpPost]
        public ActionResult Create(Booking Booking, List<BookingItem> BookingItems)
        {
            BookingVM VM = new BookingVM();
            VM.Booking = Booking;
            VM.BookingItems = BookingItems;
            VM.AddBooking();
            return View();
        }
    }
