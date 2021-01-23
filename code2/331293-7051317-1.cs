      private bool CheckCollision(Point centerPoint)
        {
            bool functionReturnValue = false;
            //wall collision
            if (centerPoint.X - 1 < 0
                || centerPoint.X + 1 > (int)LayoutRoot.ActualWidth
                || centerPoint.Y - 1 < 0
                || centerPoint.Y + 1 > (int)LayoutRoot.ActualHeight)
            {
                functionReturnValue = true;
            }
            //player collision
            if (!functionReturnValue)
            {
                foreach (var player in playerList) //all players are in this list
                {
                    for (int i = Convert.ToInt32(centerPoint.X - 2); i < centerPoint.X + 2; i++)
                    {
                        for (int j = Convert.ToInt32(centerPoint.Y - 2); j < centerPoint.Y + 2; j++)
                        {
                            var point = new Point() { X = i, Y = j };
                            if (player.CoordinatePoints.Contains(point))
                            {
                                functionReturnValue = true;
                                goto END;
                            }
                        }
                    }
                }
            }
            goto END;
         END:
            return functionReturnValue;
        }
