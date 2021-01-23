    // this bit is **broadly** comparable to ToLookup...
    Dictionary<int, List<Appointment>> apptsByCustomer =
         new Dictionary<int, List<Appointment>>();
    List<Appointment> byCust;
    foreach(Appointment appt in AppointmentList) {            
        if (!apptsByCustomer.TryGetValue(appt.customerId, out byCust)) {
            byCust = new List<Appointment>();
            apptsByCustomer.Add(appt.customerId, byCust);
        }
        byCust.Add(appt);
    }
    foreach (Customer cust in CustomerList) {
        if (apptsByCustomer.TryGetValue(cust.id, out byCust)) {
            foreach (Appointment appt in byCust) cust.appointments.Add(appt);
        }
    }
