protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
{
    base.OnElementChanged(e);
    try
    {
        if (e.OldElement != null)
        {
            nativeMap = Control as MapView;
            if (nativeMap != null)
            {
            }
        }
