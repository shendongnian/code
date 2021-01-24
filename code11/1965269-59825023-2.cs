    namespace iText.Kernel.Pdf.Canvas.Parser.Listener {
        internal class TextChunkLocationDefaultImp : ITextChunkLocation {
            ...
            /// <summary>Perpendicular distance to the orientation unit vector (i.e. the Y position in an unrotated coordinate system).
            ///     </summary>
            /// <remarks>
            /// Perpendicular distance to the orientation unit vector (i.e. the Y position in an unrotated coordinate system).
            /// We round to the nearest integer to handle the fuzziness of comparing floats.
            /// </remarks>
            private readonly int distPerpendicular;
            ...
            /// <param name="as">the location to compare to</param>
            /// <returns>true is this location is on the the same line as the other</returns>
            public virtual bool SameLine(ITextChunkLocation @as) {
                ...
                float distPerpendicularDiff = DistPerpendicular() - @as.DistPerpendicular();
                if (distPerpendicularDiff == 0) {
                    return true;
                }
                ...
            }
            ...
        }
    }
