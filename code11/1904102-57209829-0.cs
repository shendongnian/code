    private void SmoothContour(List<DataPoint> points, int severity = 1)
        {
            for (int i = 1; i < points.Count; i++)
            {
                var start = (i - severity > 0 ? i - severity + 1 : 0);
                var end = (i + severity < points.Count ? i + severity + 1 : points.Count);
                double sumX = 0, sumY = 0;
                for (int j = start; j < end; j++)
                {
                    sumX += points[j].X;
                    sumY += points[j].Y;
                }
                DataPoint sum = new DataPoint(sumX, sumY);
                DataPoint avg = new DataPoint(sum.X / (end - start), sum.Y / (end - start));
                points[i] = avg;
            }
        }
