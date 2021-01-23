    using (FileStream fs = new FileStream(srcPath, FileMode.Open, FileAccess.Read))
    {
            long fileSize = fs.Length;
            long sum = 0;   //sum here is the total of sent bytes.
            int count = 0;
            data = new byte[1024];  //8Kb buffer .. you might use a smaller size also.
            while (sum < fileSize)
            {
                count = fs.Read(data, 0, data.Length);
                network.Write(data, 0, count);
                sum += count;
            }
            network.Flush();
    }
