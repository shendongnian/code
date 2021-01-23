        foreach (CoordinateVertices cv in this.GetAll<CoordinateVertices>())
        {
            for (int i = 0; i < cv.Coordinates.Length; i++)
            {
                Vector3 old = cv.Coordinates[i];
                float xnew = old.X * Math.Cos(angle) + old.Y * Math.Sin(angle);
                float ynew = old.Y * Math.Cos(angle) - old.X * Math.Sin(angle);
    
                cv.Coordinates[i] = new Vector3(xnew, ynew, old.Z);
            }
        }
    }
