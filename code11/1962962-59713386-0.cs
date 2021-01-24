        public class Slab
        {
             //I changed property name to distinguish between class name and property name
             public int SlabCount { get; set; } 
             public string Thickness { get; set; }
             public string Material { get; set; }
             public string Batch { get; set; }
    
             public Slab(int slab, string thick, string mat, string batch)
             {
                 SlabCount = slab;
                 Thickness = thick;
                 Material = mat;
                 Batch = batch;
             }
        }
