    using (Stream postStream = request1.EndGetRequestStream(result))
    {
        using (StreamWriter writer = new StreamWriter(postStream)
        {
            writer.Write(postBody);
            writer.Write(mainBody);
            writer.Write(endBody);
        }
    }
