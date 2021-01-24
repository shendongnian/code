cs
/// <summary>
///     Attached property for use on the ItemsControl that is the host for the items being 
///     presented by this panel. Use this property to modify the virtualization mode.
/// 
///     Note that this property can only be set before the panel has been initialized 
/// </summary>
public static readonly DependencyProperty VirtualizationModeProperty = 
	DependencyProperty.RegisterAttached("VirtualizationMode", typeof(VirtualizationMode), typeof(VirtualizingStackPanel),
		new FrameworkPropertyMetadata(VirtualizationMode.Standard));
You can indeed check this behavior [later in the file](https://referencesource.microsoft.com/#PresentationFramework/src/Framework/System/Windows/Controls/VirtualizingStackPanel.cs,4184):
cs
//
// Set up info on first measure
//
if (HasMeasured)
{
	VirtualizationMode oldVirtualizationMode = InRecyclingMode ? VirtualizationMode.Recycling : VirtualizationMode.Standard;
	if (oldVirtualizationMode != virtualizationMode)
	{
		throw new InvalidOperationException(SR.Get(SRID.CantSwitchVirtualizationModePostMeasure));
	}
}
else
{
	HasMeasured = true;
}
and there is no way (according to source code) to set this `HasMeasured` property back to `False` unless you destroy and recreate the `ListView`.
