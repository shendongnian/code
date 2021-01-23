        List<byte[]> bytes = new List<byte[]>();
        ForEach string el in somelist
            {
               byte[] arr;
               System.Text.UTF8Encoding  encoding=new System.Text.UTF8Encoding();
               arr = encoding.GetBytes(el);
               bytes.add(arr);
            }
