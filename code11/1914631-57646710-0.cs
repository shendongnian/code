c#
public class ExtendedUserNotificationStore : NotificationStore
{
    private readonly IRepository<ExtendedUserNotification, Guid> _extendedUserNotificationRepository;
    private readonly IObjectMapper _objectMapper;
    private readonly IUnitOfWorkManager _unitOfWorkManager;
    public ExtendedUserNotificationStore(
        IRepository<NotificationInfo, Guid> notificationRepository, IRepository<TenantNotificationInfo, Guid> tenantNotificationRepository, IRepository<UserNotificationInfo, Guid> userNotificationRepository, IRepository<NotificationSubscriptionInfo, Guid> notificationSubscriptionRepository,
        IRepository<ExtendedUserNotification, Guid> extendedUserNotificationRepository,
        IObjectMapper objectMapper,
        IUnitOfWorkManager unitOfWorkManager)
        : base(notificationRepository, tenantNotificationRepository, userNotificationRepository, notificationSubscriptionRepository, unitOfWorkManager)
    {
        _extendedUserNotificationRepository = extendedUserNotificationRepository;
        _objectMapper = objectMapper;
        _unitOfWorkManager = unitOfWorkManager;
    }
    [UnitOfWork]
    public override async Task InsertUserNotificationAsync(UserNotificationInfo userNotification)
    {
        var extendedUserNotification = _objectMapper.Map<ExtendedUserNotification>(userNotification);
        using (_unitOfWorkManager.Current.SetTenantId(userNotification.TenantId))
        {
            await _extendedUserNotificationRepository.InsertAsync(extendedUserNotification);
            await _unitOfWorkManager.Current.SaveChangesAsync();
        }
    }
}
If you want to use `IObjectMapper`, then configure the mapping easily with `AutoMapFrom` attribute.
c#
[AutoMapFrom(typeof(UserNotificationInfo))] // Add this
public class ExtendedUserNotification : UserNotificationInfo
{
    // ...
}
# Is there a way where I can retrieve the data using the sub class even though it was published for the parent class? (Solution Y)
No, there is no supported way.
