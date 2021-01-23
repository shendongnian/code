    using System;
    using UnityEngine;
    
    namespace Util {
        public static class Math2D {
            
            public static bool Intersects(Vector2 a, Vector2 b, Rect r) {
                var minX = Math.Min(a.x, b.x);
                var maxX = Math.Max(a.x, b.x);
                var minY = Math.Min(a.y, b.y);
                var maxY = Math.Max(a.y, b.y);
                
                if (r.xMin > maxX || r.xMax < minX) {
                    return false;
                }
    
                if (r.yMin > maxY || r.yMax < minY) {
                    return false;
                }
    
                if (r.xMin < minX && maxX < r.xMax) {
                    return true;
                }
                
                if (r.yMin < minY && maxY < r.yMax) {
                    return true;
                }
    
                Func<float, float> yForX = x => a.y - (x - a.x) * ((a.y - b.y) / (b.x - a.x));
    
                var yAtRectLeft = yForX(r.xMin);
                var yAtRectRight = yForX(r.xMax);
    
                if (r.yMax < yAtRectLeft && r.yMax < yAtRectRight) {
                    return false;
                }
    
                if (r.yMin > yAtRectLeft && r.yMin > yAtRectRight) {
                    return false;
                }
    
                return true;
            }
        }
    }
