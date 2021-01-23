    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Drawing;
    public static class MathHelper
    {
        /// <summary>
        /// Gets the value at a given X using the line of best fit (Least Square Method) to determine the equation
        /// </summary>
        /// <param name="points">Points to calculate the value from</param>
        /// <param name="x">Function input</param>
        /// <returns>Value at X in the given points</returns>
        public static float LeastSquaresValueAtX(List<PointF> points, float x)
        {
            float slope = SlopeOfPoints(points);
            float yIntercept = YInterceptOfPoints(points, slope);
            return (slope * x) + yIntercept;
        }
        /// <summary>
        /// Gets the slope for a set of points using the formula:
        /// m = ∑ (x-AVG(x)(y-AVG(y)) / ∑ (x-AVG(x))²
        /// </summary>
        /// <param name="points">Points to calculate the Slope from</param>
        /// <returns>SlopeOfPoints</returns>
        private static float SlopeOfPoints(List<PointF> points)
        {
            float xBar = points.Average(p => p.X);
            float yBar = points.Average(p => p.Y);
            float dividend = points.Sum(p => (p.X - xBar) * (p.Y - yBar));
            float divisor = (float)points.Sum(p => Math.Pow(p.X - xBar, 2));
            return dividend / divisor;            
        }
        /// <summary>
        /// Gets the Y-Intercept for a set of points using the formula:
        /// b = AVG(y) - m( AVG(x) )
        /// </summary>
        /// <param name="points">Points to calculate the intercept from</param>
        /// <returns>Y-Intercept</returns>
        private static float YInterceptOfPoints(List<PointF> points, float slope)
        { 
            float xBar = points.Average(p => p.X);
            float yBar = points.Average(p => p.Y);
            return yBar - (slope * xBar);        
        }       
    }
