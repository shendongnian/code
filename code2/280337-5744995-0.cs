    public void ClearPointsQuick()
        {
            Points.SuspendUpdates();
            while (Points.Count > 0)
                Points.RemoveAt(Points.Count - 1);
            Points.ResumeUpdates();
        }
