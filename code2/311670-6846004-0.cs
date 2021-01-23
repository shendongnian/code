    e.Appearance.BackColor = Color.ForestGreen;
    e.Brick.Sides = BorderSide.None;
    
    if(e.Brick is PanelBrick) {
        PanelBrick brick = e.Brick as PanelBrick;
        if(brick.Bricks.Count > 0 && brick.Bricks[0] as IVisualBrick != null) {
            ((IVisualBrick)brick.Bricks[0]).Sides = BorderSide.None;
            ((IVisualBrick)brick.Bricks[0]).BackColor = Color.ForestGreen;
        }
    }
