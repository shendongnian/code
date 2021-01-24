            static void Main() {
            string json = "[{\"id\":1,\"netMask\":22,\"gateway\":\"10.19.0.1\",\"jenkinsUrl\":\"http://10.19.0.20:31000\",\"bridge\":\"br0\",\"ipRange\":\"10.19.0.1-10.19.3.254\"},{\"id\":11,\"netMask\":22,\"gateway\":\"10.23.0.1\",\"jenkinsUrl\":\"http://10.12.3.12:33355\",\"bridge\":\"br2\",\"ipRange\":\"10.23.0.4-10.23.0.20\"}]";
            System.Data.DataTable dt = (System.Data.DataTable)JsonConvert.DeserializeObject(json, (typeof(System.Data.DataTable)));
            Console.WriteLine(dt);
            for (int i = 0; i < dt.Columns.Count; i++) {
                Console.Write(dt.Columns[i] + " | ");
            }
            Console.WriteLine();
            for (int j = 0; j < dt.Rows.Count; j++) {
                for (int i = 0; i < dt.Columns.Count; i++) {
                    Console.Write(dt.Rows[j].ItemArray[i] + " | ");
                }
                Console.WriteLine();
            }
        }
