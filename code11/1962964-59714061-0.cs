        public class Slab
        {
            public string Thickness { get; set; }
            public string Material { get; set; }
            public string Batch { get; set; }
            public Slab(string thick, string mat, string batch)
            {
                Thickness = thick;
                Material = mat;
                Batch = batch;
            }
        }
