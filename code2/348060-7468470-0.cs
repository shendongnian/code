        private Model3DGroup CreateTriangleSide(Point3D p0, Point3D p1, Point3D p2, Material material)
        {
            MeshGeometry3D mesh = null;
            GeometryModel3D model = null;
            Model3DGroup group = new Model3DGroup();
            Vector3D normal;
            //
            // Front side of jagged part
            //
            mesh = new MeshGeometry3D();
            mesh.Positions.Add(p0);
            mesh.Positions.Add(p1);
            mesh.Positions.Add(p2);
            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(1);
            mesh.TriangleIndices.Add(2);
            normal = CalculateNormal(p0, p1, p2);
            normal = Normalize(normal);
            mesh.Normals.Add(normal);
            mesh.Normals.Add(normal);
            mesh.Normals.Add(normal);
            model = new GeometryModel3D(mesh, material);
            group.Children.Add(model);
            //
            // Front side of the surface below the jagged edge
            //
            Point3D p3 = new Point3D(p1.X, p1.Y, bh);
            Point3D p4 = new Point3D(p2.X, p2.Y, bh);
            return group;
        }
        public const double RADDEGC = (Math.PI / 180.0);
        public enum ANGLETYPE { RAD, DEG };
        /*
         * Takes the angle and the Z value to create a 3D point in space
         * 
         * @param angle The angle 
         * @param radius The radius of the circle 
         * @param z The z value
         * @param t The angle type, for example RAD (radians) or DEG (degress
         * 
         */
        public static Point3D CP(double radius, double angle, double z = 0, ANGLETYPE angtype = ANGLETYPE.RAD)
        {
            Point3D p = new Point3D();
            p.Z = z;
            //
            if (angtype ==  ANGLETYPE.RAD)
            {
                p.X = radius * Math.Cos(angle);
                p.Y = radius * Math.Sin(angle);
            }
            else
            {
                p.X = radius * Math.Cos(angle * RADDEGC);
                p.Y = radius * Math.Sin(angle * RADDEGC);
            }
            return p;
        }
        public static Vector3D CalculateNormal(Point3D p0, Point3D p1, Point3D p2)
        {
            Vector3D a1 = new Vector3D(p1.X - p0.X, p1.Y - p0.Y, p1.Z - p0.Z);
            Vector3D b1 = new Vector3D(p2.X - p0.X, p2.Y - p0.Y, p2.Z - p0.Z);
            Vector3D dir = Vector3D.CrossProduct(a1, b1);
            return dir;
        }
        public static Vector3D Normalize(Vector3D norm)
        {
            double fac1 = Math.Sqrt((norm.X * norm.X) + (norm.Y * norm.Y) + (norm.Z * norm.Z));
            if (fac1 == 0)
            {
                return norm;
            }
            norm = new Vector3D(norm.X / fac1, norm.Y / fac1, norm.Z / fac1);
            return norm;
        }
