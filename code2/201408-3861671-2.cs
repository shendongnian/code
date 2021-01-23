    Dispatcher.Invoke
    (
        new Action(
            delegate()
            {
                BmpBitmapEncoder encoder = new BmpBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(cache));
                using (FileStream file = File.OpenWrite(fName))
                {
                    encoder.Save(file);
                }
            }
        )
    );
