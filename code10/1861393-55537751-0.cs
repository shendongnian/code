    static ConcurrentDictionary<int, object> operations = new ConcurrentDictionary<int, object>();
        public async Task<IActionResult> AControllerAction()
        {
            int? calendarSlotId = 1; //await dbContext.Slots.FirstOrDefaultAsync(..., cancellationToken))?.Id;
            try
            {
                if (calendarSlotId != null && operations.TryAdd(calendarSlotId.Value, null))
                {
                    bool appointmentsAreOverlapping = false; //await dbContext.Slots.Where(...).AnyAsync(cancellationToken);
                    if (!appointmentsAreOverlapping)
                    {
                        //dbContext.Appointments.Add(...);
                        //await dbContext.SaveChangesAsync(cancellationToken);
                        return ...; //All done!
                    }
                    return ...; //Appointments are overlapping
                }
                return ...; //There is no slot or slot is being used
            }
            catch (Exception ex)
            {
                return ...; //ex exception (DB exceptions, etc)
            }
            finally
            {
                if (calendarSlotId != null)
                {
                    operations.TryRemove(calendarSlotId.Value, out object obj);
                }
            }
        }
