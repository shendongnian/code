csharp
public class BottomSheetDialogFragmentCloseAffordanceCallback : BottomSheetBehavior.BottomSheetCallback
{
    public BottomSheetDialogFragmentCloseAffordanceCallback(BottomSheetDialogFragment bottomSheetDialogFragment)
    {
        this.bottomSheetDialogFragment = bottomSheetDialogFragment ?? throw new System.ArgumentNullException(nameof(bottomSheetDialogFragment));
    }
    public override void OnSlide(View bottomSheet, float slideOffset)
    {
    }
    public override void OnStateChanged(View bottomSheet, int newState)
    {
        switch (newState)
        {
            case BottomSheetBehavior.StateCollapsed:
                ShowToolbar(bottomSheet, ViewStates.Gone);
                break;
            case BottomSheetBehavior.StateExpanded:
                if (IsViewSameHeightAsWindow(bottomSheet))
                {
                    ShowToolbar(bottomSheet, ViewStates.Visible);
                }
                break;
            case BottomSheetBehavior.StateHalfExpanded:
                break;
            case BottomSheetBehavior.StateHidden:
                bottomSheetDialogFragment.Dismiss();
                break;
        }
    }
    private void ShowToolbar(View bottomSheet, ViewStates viewState)
    {
        var toolbar = bottomSheet.FindViewById<Toolbar>(Resource.Id.toolbar);
        if (toolbar != null)
        {
            toolbar.Visibility = viewState;
        }
    }
    private bool IsViewSameHeightAsWindow(View view)
    {
        int[] locationInWindow = new int[2];
        view.GetLocationInWindow(locationInWindow);
        return locationInWindow[1] == view.RootWindowInsets.StableInsetTop;
    }
    private readonly BottomSheetDialogFragment bottomSheetDialogFragment;
}
