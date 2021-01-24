public class AnnouncementDeliveryController : BaseController
{
    private readonly ICommandHandler<CreateAnnouncementDeliveryCommand, CreateAnnouncementDeliveryCommand>
                    _createCommandHandler;
    public AnnouncementDeliveryController(
               ICommandHandler<CreateAnnouncementDeliveryCommand, CreateAnnouncementDeliveryCommand> createCommandhHndler,
               ....
   ) : base(loggingService, userQueryCommandHandler, httpContextAccessor)
   {
       _createCommandHandler = createCommandhHndler;
       ...
   }
This code is probably overengineered and too complex for whatever you want to do. Command-Query separation is a way to simplify complex domains, not add extra complexity. If the interfaces are so complex and so long that you miss such typos, you should probably rethink the design, and probably use *less* abstract types.
