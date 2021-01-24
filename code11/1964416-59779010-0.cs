    if (e.Data.GetDataPresent(typeof(System.String)))
        {
            Point clientPoint = gridViewRaces.PointToClient(new Point(e.X, e.Y));
            gridViewRaces.Rows[gridViewRaces.HitTest(clientPoint.X,
            clientPoint.Y).RowIndex].Cells[gridViewRaces.HitTest(clientPoint.X,
            clientPoint.Y).ColumnIndex].Value =
            (System.String)e.Data.GetData(typeof(System.String));
        }
