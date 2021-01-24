      double calculateSpeed(double isOpponent)
            {
                if (isOpponent == 1)
                {
                    double speedY = playerCard.Location.Y / stepY;
                    return speedY;
                }
                else
                {
                    return SOMETHING;
                }
            }
            calculateSpeed(1)
