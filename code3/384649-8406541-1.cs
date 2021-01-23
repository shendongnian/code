            Task.Factory.StartNew(() =>
                {
                    using (var source = File.OpenRead(@"D:\Temp\bbe.wav"))
                    using (var destination = File.Create(@"D:\Temp\Copy.wav"))
                    {
                        var blockUnit = source.Length / 100;
                        var total = 0L;
                        var lastValue = 0;
                        var buffer = new byte[4096];
                        int count;
                        while ((count = source.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            destination.Write(buffer, 0, count);
                            total += count;
                            if (blockUnit > 0 && total / blockUnit > lastValue)
                            {
                                this.BeginInvoke(new Action<int>(value => this.progressBar1.Value = value), lastValue = (int)(total / blockUnit));
                            }
                        }
                        this.BeginInvoke(new Action<int>(value => this.progressBar1.Value = value), 100);
                    }
                });
