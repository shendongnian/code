            int z = 0;
            foreach (FileInfo file in Variables.dir.GetFiles())
            {
                try
                {
                    this.myImageList.Images.Add(Image.FromFile(file.FullName));
                    names[z] = file.FullName;
                    z++;
                }
                catch
                {
                    Console.WriteLine("This is not an image file");
                }
            }
