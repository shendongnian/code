                    using (var file = File.Create(fileName))
                    using (view.Writer = new BinaryWriter(file))
                    {
                        view.Writer.Write(view.Data.Count);
                        foreach (Int16 dataItem in view.Data)
                        {
                            view.Writer.Write(dataItem);
                        }
                    }
