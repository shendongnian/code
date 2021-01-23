        internal static void SaveFileAsTxt()
        {
            using (FileStream streamer = new FileStream("Shipping2.txt", FileMode.Append, FileAccess.Write, FileShare.Write);)
            {
                
            }
            using(FileStream f = File.Open("Shipping2.txt", FileMode.Create)
	        {
		 
	        }
            using(StreamWriter writer = new StreamWriter("Shipping2.txt", true, Encoding.ASCII)
	        {
                foreach (var shipment in _shipments)
                {
                    string write = (shipment.Distance + "," + shipment.Distance).ToString();
                    writer.WriteLine(write);
                }
		 
	        }
        }
