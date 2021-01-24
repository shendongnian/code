    // POST: Create
    public IActionResult Create(AppointmentBookingViewModel appointmentViewModel)
    {
        if (!ModelState.IsValid)
        {
            // Server side validation of form has failed.
            // Return to the calling view and inform the user about the errors.
            return View(appointmentViewModel, "Index");
        }
        
        return View(appointmentViewModel, "<NAME_OF_YOUR_CREATED_APPOINTMENT_VIEW>");
    }
