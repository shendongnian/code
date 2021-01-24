this.OneWayBind(this.ViewModel, vm => vm.Status, view => view.TextColor, GetColor);
cs
private Color GetColor(Status status)
{
    switch (status)
    {
        case Status.Running:
            return Color.Green;
        case Status.Idle:
            return Color.Orange;
        case Status.Faulted:
            return Color.Red;
        case Status.Manual:
            return Color.Blue;
    }
}
