    private void initializeUnitPerStrip()
    {
        List<UtilitiesModel> ups = new List<UtilitiesModel>();
        int totalRow = samplingModeModel.StripRows = 7;
        int totalCol = samplingModeModel.StripColumn = 15;
        int frontOffset = 8;
        int behindOffset = 0;
        for (int c = 1; c < totalCol; c++)
        {
            for (int r = 1; r < totalRow; r++)
            {
                ups.Add(new UtilitiesModel
                {
                    Key = $"[{c}, {r}]",
                    Tag = $"{UTAC_Tags.S7Connection}DB{406},X{frontOffset}.{behindOffset}",
                    IsChecked = false;
                });
            }
        }
        UnitPerStrip = ups;
    }
