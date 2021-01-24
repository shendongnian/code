csharp
public async void EndAppointement()
{
    try 
    {
        await App.ArdaBusinessLogic.AppointmentEnd(_appointment);
        _appointmentDetailPage.IsDirty = true;
        await App.MasterNavigationPage.Navigation.PopModalAsync();
    }
    catch (Exception exception)
    {
        await App.MasterNavigationPage.Navigation.PopModalAsync();
        await App.ShowErrorPageAsync(exception);
    }
}
