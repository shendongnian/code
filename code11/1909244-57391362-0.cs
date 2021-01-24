    public class ScheduleNotificationConsumer :
        IConsumer<AssignSeat>
    {
        Uri _schedulerAddress;
        Uri _notificationService;
    
        public async Task Consume(ConsumeContext<AssignSeat> context)
        {
            if(context.Message.ReservationTime - DateTime.Now < TimeSpan.FromHours(8))
            {
                // assign the seat for the reservation
            }
            else
            {
                // seats can only be assigned eight hours before the reservation
                context.ScheduleMessage(context.Message.ReservationTime - TimeSpan.FromHours(8), context.Message);
            }
        }
    }
