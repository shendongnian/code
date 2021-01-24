                using (var image = Image.Load(imageFile))
                {
                    var proportion = (double)imageFile.Length / maxFileSize;
                    var maxWidth = (int)(image.Width / proportion);
                    var maxHeight = (int)(image.Height / proportion);
                    image.Mutate(x => x
                        .Resize(new ResizeOptions
                        {
                            Mode = ResizeMode.Max,
                            Size = new Size(maxWidth, maxHeight)
                        }));
                    // Save the Image
                }
