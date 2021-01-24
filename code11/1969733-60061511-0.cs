            /// <summary>
            /// Finds the closest point on a vector given a test point
            /// </summary>
            /// <param name="testPoint"></param>
            /// <param name="startVertex"></param>
            /// <param name="segment"></param>
            /// <returns></returns>
            public  static Vec3 VectorClosestPoint(Vec3 testPoint, Vec3 startVertex,Vec3 segment)
            {
    
    
                Vec3 onCurve = new Vec3();
    
                Vec3 b = testPoint - startVertex;
                Vec3 proj = Project(b, segment, out double dotProduct);
                Vec3 onCurveTemp = startVertex + proj;
                Vec3 endVertex = startVertex + segment;
    
                // Specify the domain of the function. 
                // This part constraints the domain if the function is not infinite. 
                Domain domainX = new Domain(startVertex.X, endVertex.X);
                Domain domainY = new Domain(startVertex.Y, endVertex.Y);
                Domain domainZ = new Domain(startVertex.Z, endVertex.Z);
    
    
                // Constraints projected points to be in the line, given the specified
                // domain of the function
                bool onLine = OnLine(domainX, domainY, domainZ, onCurveTemp);
                
                if (dotProduct < 0) onCurve = startVertex;
          
                if (dotProduct > 0 && onLine == false) onCurve = endVertex;
      
                if (dotProduct > 0 && onLine == true) onCurve = onCurveTemp;
      
    
                return onCurve;
    
    
            }
            /// <summary>
            /// Returns the dot product of two vectors 
            /// This value equals vecA.Magnitude * vecB.Magnitude * cos(theta), where theta is the angle between both vectors.
            /// </summary>
            /// <param name="vecA"></param>
            /// <param name="VecB"></param>
            /// <returns></returns>
            public static double DotProduct(Vec3 vecA, Vec3 VecB)
            {
                return vecA.X * VecB.X + vecA.Y * VecB.Y + vecA.Z * VecB.Z;
            }
    
    
    
            /// <summary>
            /// Tests whether a Point lies on a vector
            /// </summary>
            /// <param name="domainX">X- Domain</param>
            /// <param name="domainY"> Y - Domain </param>
            /// <param name="domainZ">Z - Domain</param>
            /// <param name="pt">Point to test for inclusion </param>
            /// <returns>Returns true if point is on the line, false otherwise</returns>
            public static bool OnLine(Domain domainX, Domain domainY, Domain domainZ, Vec3 pt)
    
            {
    
                if (Domain.InDomain(domainX.Min, domainX.Max, pt.X) && Domain.InDomain(domainY.Min, domainY.Max, pt.Y) &&
                  Domain.InDomain(domainZ.Min, domainZ.Max, pt.Z))
                {
                    return true;
                }
    
    
                else return false;
            }
    
    
            /// <summary>
            /// Projection of vecA on to vecB
            /// </summary>
            /// <param name="vecA"></param>
            /// <param name="vecB"></param>
            /// <returns></returns>
            public static Vec3 Project(Vec3 vecA, Vec3 vecB, out double dotProduct)
            {
                dotProduct = DotProduct(vecA, vecB);
                return dotProduct / vecB.SqrMagnitude * vecB;
                // or to save Sqr operation return dotProduct / DotProduct(vecB, vecB) * vecB;
            }
    
    /// <summary>
    /// Tests whether a number is inside a domain
    /// </summary>
    /// <param name="minVal">Minimum value</param>
    /// <param name="maxVal">Maximum value</param>
    /// <param name="numToTest">Number to test </param>
    /// <returns>True if in domain, false otherwise </returns>
    public static bool InDomain(double minVal, double maxVal, double numToTest)
    {
        double min = 0;
        double max = 0;
        if (minVal > maxVal)
        {
            min = maxVal;
            max = minVal;
        }
    
        if (minVal < maxVal)
        {
            min = minVal;
            max = maxVal;
        }
    
    
        if (numToTest >= min && numToTest <= max) return true;
    
        else return false;
    
    }   
    
