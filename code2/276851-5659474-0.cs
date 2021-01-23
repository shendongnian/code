    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace SerializeFloatArray
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Create a fixed-length array of floats:
                float[] a = new float[10];
    
                // Initialize the array to contain some content.
                for (int i = 0; i < a.Length; i++)
                {
                    a[i] = float.Parse(i.ToString() + '.' + (i + 1).ToString());
                }
    
                // Create an XML document containing XML elements named as you require.
                int j = 0;
                var doc = new XDocument(
                    new XElement("floats",
                        from f in a
                        select new XElement("f." + j++.ToString(), f)));
    
                // Display doc serialized to text. You could write this to a 
                // file if you want.
                Console.WriteLine(doc);
            }
        }
    }
