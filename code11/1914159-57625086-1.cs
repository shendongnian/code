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
Second, looking at XF source code:
csharp
protected override async Task<Page> OnPopModal(bool animated)
{
    Page modal = ModalStack[ModalStack.Count - 1];
    if (_owner.OnModalPopping(modal))
    {
        _owner.OnPopCanceled();
        return null;
    }
    Page result = await base.OnPopModal(animated);
    result.Parent = null;
    _owner.OnModalPopped(result);
    return result;
}
It seems that your modal stack is messed up: meaning you are trying to pop pages that are not on the stack. Are you sure you're on a modal page? Maybe use `PopAsync` instead of `PopModalAsync`.
