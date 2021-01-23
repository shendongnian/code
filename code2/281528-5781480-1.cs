    public class BspNode
    {
        public List<Vector3> Vertices { get; set; }
    
        // plane equation coefficients
        float A, B, C, D;
    
        BspNode front;
        BspNode back;
    
        public BspNode(Vector3 v1, Vector3 v2, Vector3 v3)
        {
            Vertices = new List<Vector3>();
            Vertices.AddRange(new[] { v1, v2, v3 });
            GeneratePlaneEquationCoefficients();
        }
    
        void GeneratePlaneEquationCoefficients()
        {
    
            // derive the plane equation coefficients A,B,C,D from the input vertex list.
        }
    
        bool IsInFront(Vector3 point)
        {
            bool pointIsInFront=true;
            // substitute point.x/y/z into the plane equation and compare the result to D
            // to determine if the point is in front of or behind the partition plane.
            if (pointIsInFront && front!=null)
            {
                // POINT is in front of this node's plane, so check it against the front list.
                pointIsInFront = front.IsInFront(point);
            }
            else if (!pointIsInFront && back != null)
            {
                // POINT is behind this plane, so check it against the back list.
                pointIsInFront = back.IsInFront(point);
            }
            /// either POINT is in front and there are no front children,
            /// or POINT is in back and there are no back children. 
            /// Either way, recursion terminates here.
            return pointIsInFront;	          
        }
    
        /// <summary>
        /// determines if the line segment defined by v1 and v2 intersects any geometry in the tree.
        /// </summary>
        /// <param name="v1">vertex that defines the start of the ray</param>
        /// <param name="v2">vertex that defines the end of the ray</param>
        /// <returns>true if the ray collides with the mesh</returns>
        bool SplitsRay(Vector3 v1, Vector3 v2)
        {
    
            var v1IsInFront = IsInFront(v1);
            var v2IsInFront = IsInFront(v2);
            var result = v1IsInFront!=v2IsInFront;
    
            if (!result)
            {
                /// both vertices are on the same side of the plane,
                /// so this node doesn't split anything. Check it's children.
                if (v1IsInFront && front != null)
                    result =  front.SplitsRay(v1, v2);
                else if (!v1IsInFront && back != null)
                    result = back.SplitsRay(v1, v2);
            }
            else
            {
                /// this plane splits the ray, but the intersection point may not be within the face boundaries.
                /// 1. calculate the intersection of the plane and the ray : intersection
                /// 2. create two new line segments: v1->intersection and intersection->v2
                /// 3. Recursively check those two segments against the rest of the tree.
                var intersection = new Vector3();
    
                /// insert code to magically calculate the intersection here.
                
                var frontSegmentSplits = false;
                var backSegmentSplits = false;
    
    
                if (front!=null)
                {
                    if (v1IsInFront) frontSegmentSplits=front.SplitsRay(v1,intersection);
                    else if (v2IsInFront) frontSegmentSplits=front.SplitsRay(v2,intersection);
                }
                if (back!=null)
                {
                    if (!v1IsInFront) backSegmentSplits=back.SplitsRay(v1,intersection);
                    else if (!v2IsInFront) backSegmentSplits=back.SplitsRay(v2,intersection);
                }
    
                result = frontSegmentSplits || backSegmentSplits;
            }
    
            return result;
        }
    } 
  
