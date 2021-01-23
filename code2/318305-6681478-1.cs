    public void ImportMessageBody(IMessageBody body)
    {
        Task.Factory.StartNew(() =>
            {
                string fileName = GetFileNameFromMagicalPlace();
                using (FileStream fs = new FileStream(fileName, FileMode.Append))
                {
                    body.Data.CopyTo(fs); // <---- throws System.IOException right here
                }
            });
    }
