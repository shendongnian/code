        private static WeightClass WeightClassFromRow(DataGridView gvSegments, int rowNumber)
        {
            return WeightClassFromChar(gvSegments.Rows[rowNumber].Cells[SegmentColumns.WeightClass].Value as string);
        }
        private static WeightClass WeightClassFromChar(string weightClassString)
        {
            if (string.IsNullOrEmpty(weightClassString))
                return WeightClass.None;
            switch (weightClassString[0])
            {
                case 'H':
                    return WeightClass.Heaveyweight;
                case 'L':
                    return WeightClass.Lightweight;
                default:
                    return WeightClass.None;
            }
        }
