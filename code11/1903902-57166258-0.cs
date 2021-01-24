    static long MeasureAttachmentSize (MimePart part)
    {
        using (var measure = new MimeKit.IO.MeasuringStream ()) {
            part.Content.DecodeTo (measure);
            return measure.Length;
        }
    }
