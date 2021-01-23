        /// <summary>
        ///     Computes confidence interval.
        /// </summary>
        public static class ConfidenceInterval
        {
            /// <summary>
            ///     Calculates the Wilson Score Interval based on the total positives and the class positives (like positive votes).
            ///     <see href="https://en.wikipedia.org/wiki/Binomial_proportion_confidence_interval#Wilson_score_interval" />
            ///     <see href="http://www.evanmiller.org/how-not-to-sort-by-average-rating.html" />
            /// </summary>
            /// <param name="positives">Number of class positives.</param>
            /// <param name="total">Total number of positives.</param>
            /// <param name="confidence">
            ///     Confidence level or coverage. Quantifies the level of confidence that the deterministic
            ///     parameter is captured by the interval. Defaults to 0.95 (95%).
            /// </param>
            public static Interval WilsonScoreInterval(long positives, long total, double confidence = 0.95)
            {
                if (total <= 0 || total < positives)
                {
                    return new Interval();
                }
                positives = positives < 0 ? 0 : positives;
                var quantile = 1 - (1 - confidence) / 2;
                var z = PNormalDist(quantile);
                double n = total;
                var pHat = positives / n;
                var z2 = z * z;
                var hat = pHat + z2 / (2 * n);
                var sqrt = z * Math.Sqrt((pHat * (1 - pHat) + z2 / (4 * n)) / n);
                var divisor = 1 + z2 / n;
                return new Interval {
                    LowerBound = (hat - sqrt) / divisor,
                    UpperBound = (hat + sqrt) / divisor
                };
            }
            /// <summary>
            ///     Inverse of normal-distribution. P( (-infinity, x] ) = quantile -> x
            /// </summary>
            /// <param name="quantile">Probability quantile. <see href="https://en.wikipedia.org/wiki/Quantile" /></param>
            /// <returns>The inverse Cumulative Density Function or P-value of the corresponding integral.</returns>
            private static double PNormalDist(double quantile)
            {
                if (quantile < 0.0 || 1.0 < quantile || Math.Abs(quantile - 0.5) < 0.0000001)
                {
                    return 0.0;
                }
                double[] pNormTable = {
                    1.570796288,
                    0.03706987906,
                    -0.8364353589e-3,
                    -0.2250947176e-3,
                    0.6841218299e-5,
                    0.5824238515e-5,
                    -0.104527497e-5,
                    0.8360937017e-7,
                    -0.3231081277e-8,
                    0.3657763036e-10,
                    0.6936233982e-12
                };
                var temp1 = quantile > 0.5 ? 1.0 - quantile : quantile;
                var temp2 = -Math.Log(4.0 * temp1 * (1.0 - temp1));
                var temp3 = pNormTable[0];
                for (var i = 1; i < 11; i++)
                {
                    temp3 += pNormTable[i] * Math.Pow(temp2, i);
                }
                return quantile > 0.5 ? Math.Sqrt(temp3 * temp2) : -Math.Sqrt(temp3 * temp2);
            }
            public class Interval
            {
                /// <summary>
                ///     Lower bound.
                /// </summary>
                public double LowerBound { get; set; }
                /// <summary>
                ///     Upper bound.
                /// </summary>
                public double UpperBound { get; set; } = 1;
            }
        }
