        double CanonizeAngle(double angle)
        {
            if (angle > Math.PI)
            {
                do
                {
                    angle -= MathHelper.TwoPi;
                }
                while (angle > Math.PI);
            }
            else if (angle < -Math.PI)
            {
                do
                {
                    angle += MathHelper.TwoPi;
                } while (angle < -Math.PI);
            }
            return angle;
        }
        double VectorToAngle(Vector2 vector)
        {
            Vector2 direction = Vector2.Normalize(vector);
            return Math.Atan2(direction.Y, direction.X);
        }
        bool IsPointWithinCone(Vector2 point, Vector2 conePosition, double coneAngle, double coneSize)
        {
            double toPoint = VectorToAngle(point - conePosition);
            double angleDifference = CanonizeAngle(coneAngle - toPoint);
            double halfConeSize = coneSize * 0.5f;
            return angleDifference >= -halfConeSize && angleDifference <= halfConeSize;
        }
