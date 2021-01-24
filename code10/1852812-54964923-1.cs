        static void Main(string[] args)
        {
            ReadCsv();
            Console.WriteLine("...");
            Console.ReadLine();
        }
        private static void ReadCsv()
        {
            string desk = System.IO.Directory.GetParent(@"../../").FullName;
            String path = $@"{desk}\filecsv.csv";
            var csvlines = File.ReadAllLines(path);
            Console.WriteLine("Parsing the csv file");
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
                            campos[i] = campos[i].Replace("\"","");
                        }
                    }
                    newline += $"{campos[i]} \t";
                }
                //puts the values in the clsEstadoCuenta
                var tmpFecha = campos[0].Split('/');
                nR.FechaTransaccion = new DateTime(Convert.ToInt32(tmpFecha[2]), Convert.ToInt32(tmpFecha[1]), Convert.ToInt32(tmpFecha[0]));
                nR.Descripcion = (String.IsNullOrEmpty(campos[1])) ? "" : campos[1];
                nR.Referencia = (String.IsNullOrEmpty(campos[2])) ? "" : campos[2];
                nR.Debito = (String.IsNullOrEmpty(campos[4])) ? 0 : Convert.ToDouble(campos[4]);
                nR.Credito = (String.IsNullOrEmpty(campos[5])) ? 0 : Convert.ToDouble(campos[5]);
                nR.Payee = "A";
                Console.WriteLine($"{newline}");
            }
        }
