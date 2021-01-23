    long fileSize = // your file size that you are going to receive it.
    using (FileStream fs = new FileStream(destPath, FileMode.Create, FileAccess.Write))
    {
            int count = 0;
            long sum = 0;   //sum here is the total of received bytes.
            data = new byte[1024 * 8];  //8Kb buffer .. you might use a smaller size also.
            while (sum < fileSize)
            {
                if (network.DataAvailable)
                {
                    {
                        count = network.Read(data, 0, data.Length);
                        fs.Write(data, 0, count);
                        sum += count;
                    }
                }
            }
    }
