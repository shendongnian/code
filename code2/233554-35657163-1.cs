    private void GrdBallPenetrations_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            e.NewItem = new BallPenetration
            {
                Id              = Guid.NewGuid(),
                CarriageWay     = CariageWayType.Plus,
                LaneNo          = 1,
                Position        = Positions.BetweenWheelTracks
            };
        }
