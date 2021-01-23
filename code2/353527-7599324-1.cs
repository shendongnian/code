        private static Point CorrectForAllowedArea(Point previousLocation, Point newLocation, Rect allowedArea, Rect newBox)
        {
            // get area that encloses both rectangles
            Rect enclosingRect = Rect.Union(allowedArea, newBox);
            // get corners of outer rectangle, index matters for getting opposite corner
            var outsideCorners = new[] { enclosingRect.TopLeft, enclosingRect.TopRight, enclosingRect.BottomRight, enclosingRect.BottomLeft }.ToList();
            // get corners of inner rectangle
            var insideCorners = new[] { allowedArea.TopLeft, allowedArea.TopRight, allowedArea.BottomRight, allowedArea.BottomLeft }.ToList();
            // get the first found corner that both rectangles share
            Point sharedCorner = outsideCorners.First((corner) => insideCorners.Contains(corner));
            // find the index of the opposite corner
            int oppositeCornerIndex = (outsideCorners.IndexOf(sharedCorner) + 2) % 4;
            // calculate the displacement of the inside and outside opposite corner, this is the displacement outside the allowed area
            Vector rectDisplacement = outsideCorners[oppositeCornerIndex] - insideCorners[oppositeCornerIndex];
            // subtract that displacement from the total displacement that moved the shape outside the allowed area to get the displacement inside the allowed area
            Vector allowedDisplacement = (newLocation - previousLocation) - rectDisplacement;
            // use that displacement on the display location of the shape
            return previousLocation + allowedDisplacement;
            // move or resize the shape inside the allowed area, right upto the border, using the new returned location
        }
