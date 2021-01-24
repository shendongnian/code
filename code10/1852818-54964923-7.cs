        static void Main(string[] args)
        {
            ReadCsvList();
            Console.WriteLine("...");
            Console.ReadLine();
        }
        private static void ReadCsvList()
        {
            string desk = System.IO.Directory.GetParent(@"../../").FullName;
            String path = $@"{desk}\filecsv.csv";
            var csvlines = File.ReadAllLines(path);
            //build header
            var header = csvlines[1].Split(',');
            clsEstadoCuenta nR = new clsEstadoCuenta();
            nR.NumeroCuenta = (String.IsNullOrEmpty(header[1])) ? "" : header[1];
            nR.CodigoPais = 504;
            nR.Banco = "Fichosa";
            nR.Moneda = (String.IsNullOrEmpty(header[2])) ? "" : header[2];
            nR.TasaCambio = 24.6;
            //build list of data
            foreach (var lines in csvlines.Skip(7))
            {
                var campos = lines.Split(',');
                //mount line
                string newline = "";
                for (int i = 0; i < campos.Count(); i++)
                {
                    //Here the numbers that were divided by the Spli (',') 
                    //are reassembled and saved in their respective fields.
                    if (!string.IsNullOrEmpty(campos[i]))
                    {
                        if (campos[i][0] == '\"')
                        {
                            campos[i] = campos[i] + campos[i + 1];
                            campos[i + 1] = "";
                            campos[i] = campos[i].Replace("\"", "");
                        }
                    }
                    newline += $"{campos[i]} \t";
                }
                //puts the values in the clsEstadoCuenta
                var tmpFecha = campos[0].Split('/');
                nR.FechaTransaccion.Add(new DateTime(Convert.ToInt32(tmpFecha[2]), Convert.ToInt32(tmpFecha[1]), Convert.ToInt32(tmpFecha[0])));
                nR.Descripcion.Add(String.IsNullOrEmpty(campos[1]) ? "" : campos[1]);
                nR.Referencia.Add(String.IsNullOrEmpty(campos[2]) ? "" : campos[2]);
                nR.Debito.Add(String.IsNullOrEmpty(campos[4]) ? 0 : Convert.ToDouble(campos[4]));
                nR.Credito.Add(String.IsNullOrEmpty(campos[5]) ? 0 : Convert.ToDouble(campos[5]));
                nR.Payee.Add("A");
            }
            //I will only display on the screen in 
            //this function below, it gets cleaner code.
            ListDataCSV(nR);
        }
        private static void ListDataCSV(clsEstadoCuenta data)
        {
            Console.WriteLine("Parsing the csv file");
            Console.WriteLine($"Conta: {data.NumeroCuenta} \t Pais: {data.CodigoPais} \t Banco: {data.Banco}");
            Console.WriteLine($"Moeda: {data.Moneda} \t\t Cambio: {data.TasaCambio}");
            Console.WriteLine($"");
            Console.WriteLine($"Date \t\t Description \t\t Númber Reference \t\t Débit \t Crédit \t Balance");
            for (int i = 0; i < data.GetTransactionsNumber(); i++)
            {
                var vdata = data.FechaTransaccion[i].ToString("dd/MM/yy HH:mm");
                var vdescription = data.Descripcion[i];
                var vreference = data.Referencia[i];
                var vdebito = data.Debito[i];
                var vcredito = data.Credito[i];
                var vpayee = data.Payee[i];
                Console.WriteLine($"{vdata} \t {vdescription} \t\t {vreference} \t\t {vdebito} \t {vcredito} \t {vpayee}");
            }
        }
