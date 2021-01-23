     public static partial class Convert
        {
            /// <summary>
            /// Converts number of dots in to millimeters in length
            /// </summary>
            /// <param name="dots">length in dots</param>
            /// <returns>length in millimeters</returns>
            public static float DotsToMm(int dots)
            {
                return dots * 0.125125f;
            }
            /// <summary>
            /// Converts millimeters to dots in length.
            /// </summary>
            /// <param name="mm">length in millimeters</param>
            /// <returns>length in dots</returns>
            public static int MmToDots(float mm)
            {
                return (int)(mm / 0.125125f);
            }
            /// <summary>
            /// Converts number of dots in to inches in length
            /// </summary>
            /// <param name="dots">length in dots</param>
            /// <returns>length in inches</returns>
            public static float DotsToInches(int dots)
            {
                return dots * 0.0049125f;
            }
            /// <summary>
            /// Converts inches to dots in length.
            /// </summary>
            /// <param name="mm">length in inches</param>
            /// <returns>length in dots</returns>
            public static int InchesToDots(float Inches)
            {
                return (int)(Inches / 0.0049125f);
            }
        }
