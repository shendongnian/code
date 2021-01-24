                byte[] bytes;
                using (var memoryStream = new System.IO.MemoryStream())
                {
                    photo.GetStream().CopyTo(memoryStream);
                    bytes = memoryStream.ToArray();
                }
