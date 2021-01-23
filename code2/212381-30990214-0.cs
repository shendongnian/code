    var files = Directory.GetFiles(@"D:\DCIM","*.CR2");
                for(var i = 0; i < files.Length; i++) {
                    Console.Write("{0,-4}: {1} => ", i, files[i]);
                    var bmpDec = BitmapDecoder.Create(new Uri(files[i]), BitmapCreateOptions.DelayCreation, BitmapCacheOption.None);
                    var bmpEnc = new JpegBitmapEncoder();
                    bmpEnc.QualityLevel = 100;
                    bmpEnc.Frames.Add(bmpDec.Frames[0]);
                    var oldfn = Path.GetFileName(files[i]);
                    var newfn = Path.ChangeExtension(oldfn, "JPG");
                    using(var ms = File.Create(Path.Combine(@"D:\DCIM\100CANON", newfn), 10000000)) {
                        bmpEnc.Save(ms);
                    }
                    Console.WriteLine(newfn);
                }
