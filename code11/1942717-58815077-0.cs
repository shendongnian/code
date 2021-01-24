    public static class WaypointExtensions
    {
        public static bool IsStartOrEnd(this Waypoint waypoint)
        {
            if (waypoint == null)
            {
                return false;
            }
            return (waypoint.Type == Waypointtype.Start || waypoint.Type == Waypointtype.End);
        }
    }
