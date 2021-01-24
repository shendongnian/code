foreach (var route in routeList)
{
    if (route.RouteSegmentPoints != null)
    {
        Polyline polyline;
        int color = Android.Graphics.Color.Black;
        PolylineOptions poly = Utils.GetPolyLineOptions(color, 100, true, 100);
        for (int i=0;i<route.RouteSegmentPoints.Count;i++)
        {
            point = new 
LatLng(Convert.ToDouble(route.RouteSegmentPoints[i].Latitude), 
Convert.ToDouble(route.RouteSegmentPoints[i].Longitude));
            poly.Add(point);
        }
        polyline = _map.AddPolyline(poly);
    }
}
If that doesn't work either, you could try wrapping the last line from my code to Run On the Ui Thread because depending on the thread this code is being executed on it may not be updating the UI:
Activity.RunOnUiThread(() => {
    polyline = _map.AddPolyline(poly);
});
