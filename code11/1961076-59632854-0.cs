    public void SaveFile(string fileName)
            {
                string path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
                string filePath = System.IO.Path.Combine(path, fileName);
                if (!System.IO.File.Exists(filePath))
                {
                    using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath, true))
                    {
                        writer.WriteLine(DateTime.Now.ToString() + ": " + "Example .txt created using Xamarin.");
                    }
                }
                else
                {
                    System.IO.File.Delete(filePath);
                    using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath, true))
                    {
                        writer.WriteLine(DateTime.Now.ToString() + ": " + "Example .txt created using Xamarin.");
                    }
                }
            }
            /// <summary>
            /// To receive file from Android Phone
            /// </summary>
            public string ReceiveFile(string fileName)
            {
                string path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
                string filePath = System.IO.Path.Combine(path, fileName);
                return filePath;
            }
