    string previousValue = gridViewRaces.Rows[gridViewRaces.HitTest(clientPoint.X,
                clientPoint.Y).RowIndex].Cells[gridViewRaces.HitTest(clientPoint.X,
                clientPoint.Y).ColumnIndex].Value.ToString();
                gridViewRaces.Rows[gridViewRaces.HitTest(clientPoint.X,
                clientPoint.Y).RowIndex].Cells[gridViewRaces.HitTest(clientPoint.X,
                clientPoint.Y).ColumnIndex].Value =
                (System.String)e.Data.GetData(typeof(System.String));
