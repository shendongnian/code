`
Queue<byte[]> byteArrayQueue = helper.GetQueue(); // Gets approximately 10k items.
while (byteArrayQueue.Any())
{
    using (var ms = new MemoryStream(byteArrayQueue.Dequeue()))
    {
        using (var bm = new Bitmap(ms))
        {
            bm.Save(fileLocation);
        }
    }
}
