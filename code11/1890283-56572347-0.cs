if (disable)
{
    // disable
    MixedRealityToolkit.SpatialAwarenessSystem.Disable();
}
else
{
    // enable
    MixedRealityToolkit.SpatialAwarenessSystem.Enable()
}
You can use the following code to enable/disable just the visualization but keep the colliders on:
foreach(var observer in MixedRealityToolkit.SpatialAwarenessSystem.GetObservers())
{
    var meshObserver = observer as IMixedRealitySpatialAwarenessMeshObserver;
    if (meshObserver != null)
    {
        meshObserver.DisplayOption = SpatialAwarenessMeshDisplayOptions.None;
    }
}
