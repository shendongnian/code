        private static void RubikCube()
        {
            Bitmap[] bitmaps = CreateRubikBitmaps();
            Scene scene = new Scene();
            //create a box and convert it to mesh, so we can manually specify the material per face
            var box = (new Box()).ToMesh();
            //create a material mapping, the box mesh generated from Box primitive class contains 6 polygons, then we can reference the material of polygon(specified by MappingMode.Polygon) by index(ReferenceMode.Index)
            var materials = (VertexElementMaterial)box.CreateElement(VertexElementType.Material, MappingMode.Polygon, ReferenceMode.Index);
            //and each polygon uses different materials, the indices of these materials are specified below
            materials.SetIndices(new int[] {0, 1, 2, 3, 4, 5});
            //create the node and materials(referenced above)
            var boxNode = scene.RootNode.CreateChildNode(box);
            for (int i = 0; i < bitmaps.Length; i++)
            {
                //create material with texture
                var material = new LambertMaterial();
                var tex = new Texture();
                using (var ms = new MemoryStream())
                {
                    bitmaps[i].Save(ms, ImageFormat.Png);
                    var bytes = ms.ToArray();
                    //Save it to Texture.Content as embedded texture, thus the scene with textures can be exported into a single FBX file.
                    tex.Content = bytes;
                    //Give it a name and save it to disk so it can be opened with .obj file 
                    tex.FileName = string.Format("cube_{0}.png", i);
                    File.WriteAllBytes(tex.FileName, bytes);
                    //Dispose the bitmap since we're no longer need it.
                    bitmaps[i].Dispose();
                }
                //the texture is used as diffuse
                material.SetTexture(Material.MapDiffuse, tex);
                //attach it to the node where contains the box mesh
                boxNode.Materials.Add(material);
            }
            //save it to file
            //3D viewer of Windows 10 does not support multiple materials, you'll see same textures in each face, but the tools from Autodesk does
            scene.Save("test.fbx", FileFormat.FBX7500ASCII);
            //NOTE: Multiple materials of mesh in Aspose.3D's OBJ Exporter is not supported yet.
            //But we can split the mesh with multiple materials into different meshes by using PolygonModifier.SplitMesh
            PolygonModifier.SplitMesh(scene, SplitMeshPolicy.CloneData);
            //following code will also generate a material library file(test.mtl) which uses the textures exported in above code.
            scene.Save("test.obj", FileFormat.WavefrontOBJ);
        }
        private static Bitmap[] CreateRubikBitmaps()
        {
            Brush[] colors = { Brushes.White, Brushes.Red, Brushes.Blue, Brushes.Yellow, Brushes.Orange, Brushes.Green};
            Bitmap[] bitmaps = new Bitmap[6];
            //initialize the cell colors
            int[] cells = new int[6 * 9];
            for (int i = 0; i < cells.Length; i++)
            {
                cells[i] = i / 9;
            }
            //shuffle the cells
            Random random = new Random();
            Array.Sort(cells, (a, b) => random.Next(-1, 2));
            //paint each face
            // size of each face is 256px
            const int size = 256;
            // size of cell is 80x80 
            const int cellSize = 80;
            // calculate padding size between each cell
            const int paddingSize = (size - cellSize * 3) / 4;
            int cellId = 0;
            for (int i = 0; i < 6; i++)
            {
                bitmaps[i] = new Bitmap(size, size, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                using (Graphics g = Graphics.FromImage(bitmaps[i]))
                {
                    g.Clear(Color.Black);
                    for (int j = 0; j < 9; j++)
                    {
                        //calculate the cell's position
                        int row = j / 3;
                        int column = j % 3;
                        int y = row * (cellSize + paddingSize) + paddingSize;
                        int x = column * (cellSize + paddingSize) + paddingSize;
                        Brush cellBrush = colors[cells[cellId++]];
                        //paint cell
                        g.FillRectangle(cellBrush, x, y, cellSize, cellSize);
                    }
                }
            }
            return bitmaps;
        }
