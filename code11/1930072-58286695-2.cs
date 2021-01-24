    public struct Face3 
    {
        public Face3(int indexA, int indexB, int indexC)
        {
            this.IndexA = indexA;
            this.IndexB = indexB;
            this.IndexC = indexC;
        }
        public readonly int IndexA, IndexB, IndexC;
    }
    public class Mesh3 
    {
        public Mesh3(int n_nodes, int n_elements)
        {
            this.Nodes = new Vector3[n_nodes];
            this.Faces = new Face3[n_elements];
        }
        public Mesh3(Vector3[] nodes, Face3[] faces)
        {
            this.Nodes = nodes;
            this.Faces = faces;
        }
        public Vector3[] Nodes { get; }
        public Face3[] Faces { get; }
        public void CalcRigidBodyProperties(double density)
        {
            double sum_vol = 0;
            Vector3 sum_cg = Vector3.Zero;
            for (int i = 0; i < Faces.Length; i++)
            {
                var face = this.Faces[i];
                Vector3 a = this.Nodes[face.IndexA];
                Vector3 b = this.Nodes[face.IndexB];
                Vector3 c = this.Nodes[face.IndexC];
                double face_vol = Vector3.Dot(a, Vector3.Cross(b,c))/6;
                sum_vol += face_vol;
                Vector3 face_cg = (a+b+c)/4;
                sum_cg += frace_vol*face_cg;
            }
            // scale volume with density for mass
            var mass = density*sum_vol;
            // find center of mass by dividing by total volume
            var cg = sum_cg / sum_vol;
            ...
        }
        public static Mesh3 FromStl(string filename, double scale = 1)
        {
            // Imports a binary STL file
            // Code Taken From:
            // https://sukhbinder.wordpress.com/2013/12/10/new-fortran-stl-binary-file-reader/
            // Aug 27, 2019
            var fs = File.OpenRead(filename);
            var stl = new BinaryReader(fs);
            var header = new string(stl.ReadChars(80));
            var n_elems = stl.ReadInt32();
            var nodes = new List<Vector3>();
            var faces = new List<Face3>();
            bool FindIndexOf(Vector3 node, out int index)
            {
                for (index = 0; index < nodes.Count; index++)
                {
                    if (nodes[index].Equals(node, TrigonometricPrecision))
                    {
                        return true;
                    }
                }
                index = -1;
                return false;
            }
            for (int i = 0; i < n_elems; i++)
            {
                var normal = new Vector3(
                    stl.ReadSingle(),
                    stl.ReadSingle(),
                    stl.ReadSingle());
                var a = new Vector3(
                    scale*stl.ReadSingle(),
                    scale*stl.ReadSingle(),
                    scale*stl.ReadSingle());
                var b = new Vector3(
                    scale*stl.ReadSingle(),
                    scale*stl.ReadSingle(),
                    scale*stl.ReadSingle());
                var c = new Vector3(
                    scale*stl.ReadSingle(),
                    scale*stl.ReadSingle(),
                    scale*stl.ReadSingle());
                // burn two bytes
                var temp = stl.ReadBytes(2);
                // get index of next point, and add point to list of nodes
                index_a = nodes.Count;
                nodes.Add(a);
                index_b = nodes.Count;
                nodes.Add(b);
                index_c = nodes.Count;
                nodes.Add(c);
                // add face from the three index values
                faces.Add(new Face3( index_a, index_b, index_c ));
            }
            stl.Close();
            return new Mesh3(nodes.ToArray(), faces.ToArray());
        }
    }
