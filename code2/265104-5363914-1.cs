                    using (var file = File.Create(fileName))
                    using (view.Writer = new BinaryWriter(file))
                    {
                        Int16 count = (Int16) view.Data.Count;
                        view.Writer.Write(count);
                        foreach (Int16 dataItem in view.Data)
                        {
                            view.Writer.Write(dataItem);
                        }
                    }
