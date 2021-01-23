        static IEnumerable<IEnumerable<string>> ReadBatches(string fileName)
        {
            var file = File.OpenText(fileName);
            var batchItems = new List<string>();
            while (!file.EndOfStream)
            {
                // clear the batch list
                batchItems.Clear();
                // read file in batches of 3
                // your logic on splitting batches might differ
                for (int i = 0; i < 3; i++)
                {
                    if (file.EndOfStream)
                        break;
                    batchItems.Add(file.ReadLine());
                }
                // this allows the caller to perform processing, and only
                // returns back here when they pull on the next item in the
                // IEnumerable
                yield return batchItems;                
            }
            file.Close();
        }
