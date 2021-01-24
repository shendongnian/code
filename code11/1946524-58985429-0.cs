public class BookingDetailController : BaseController
{
    private readonly IReservationDetailApi _reservationDetailApi;
    public BookingDetailController(IReservationDetailApi reservationDetailApi)
    {
        _reservationDetailApi = reservationDetailApi;
    }
    public async Task<ActionResult> Get([Description("The details for a reservation")] string hotelCode)
    {
        var result = _reservationDetailApi.GetReservationDetail(hotelCode);
        return Ok(result);
    }
}
2. Change your service to implement the `IReservationDetailService` interface and change the `GetReservationsFeature` extension method to register the `IReservationDetailService` interface:
public class ReservationDetailsBogusService : IReservationDetailService
{
    public async Task<List<ReservationDetails>> GetReservationDetail(string hotelCode)
    {
        ....
    }
}
public static class ServiceCollectionExtensions
{
    public static void GetReservationsFeature(this IServiceCollection serviceCollection, IConfiguration config)
    {
        // other code removed but stays the same
        ...
        serviceCollection.AddScoped<IReservationDetailService, ReservationDetailsBogusService>();
    }
}
