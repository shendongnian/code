    public async Task Fn(..., CancellationToken cancellationToken)
    {
        // suppose "appointment" is our entity, we will store it as "pending" using
        // PendingUntil property (which is Nullable<DateTimeOffset>).
        // an appointment is in "pending" state if the PendingUntil property is set
        // (not null), and its value is >= UtcNow
        var utcNow = DateTimeOffset.UtcNow;
        appointment.PendingUntil = utcNow.AddSeconds(5);
        // we will then use this property to find out if there are other pending appointments
        var calendarSlotExists = await dbContext.Slots.Where(...).AnyAsync(cancellationToken);
        var appointmentsAreOverlapping = await dbContext.Appointments
                                                        .Where(...)
                                                        .Where(a => a.PendingUntil == null || 
                                                                    a.PendingUntil >= now)
                                                        .AnyAsync(cancellationToken);
        if (calendarSlotExists && !appointmentsAreOverlapping)
            dbContext.Appointments.Add(appointment);
        else
            return BadRequest(); // whatever you what to return
        await dbContext.SaveChangesAsync(cancellationToken); // save the pending appointment
        
        // now check if the pending appointment is still valid
        var calendarSlotStillExists = await dbContext.Slots.Where(...).AnyAsync(cancellationToken); // same query as before
        // a note on the calendar slot existance: you should of course negate any
        // slot deletion for (pending or not) appointments.
        // we will then check if there is any other appointment in pending state that was
        // stored inside the database "before" this one.
        // this query is up to you, below you'll find just an example
        var overlappingAppointments = await dbContext.Appointments.Where(...)
                                                     .Where(a => a.Id != appointment.Id &&
                                                                 a.PendingUntil == null || 
                                                                 a.PendingUntil >= now)
                                                     .ToListAsync(cancellationToken);
        // we are checking if other appointments (pending or not) have been written to the DB
        // of course we need to exclude the appointment we just added
        if (!calendarSlotStillExists || overlappingAppointments.Any(a => a.PendingUntil == null || a.PendingUntil < appointment.PendingUntil)
        {
            // concurrency check failed
            // this means that another appointment was added after our first check, but before our appointment.
            // we have to remove the our appointment
            dbContext.Appointments.Remove(appointment);
            await dbContext.SaveChangesAsync(cancellationToken); // restore DB
            return BadRequest(); // same response as before
        }
        
        // ok, we can remove the pending state
        appointment.PendingUntil = null;
           
        await dbContext.SaveChangesAsync(cancellationToken); // insert completed
        return Ok();
    }
