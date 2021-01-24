            var response = context.BeginGetReadStream(MyFile, _args, (ar) =>
            {
                using (System.IO.FileStream output = new FileStream(path, FileMode.Create))
                {
                    aDS.EndGetReadStream(ar).Stream.CopyTo(output);
                }
            }, null);
