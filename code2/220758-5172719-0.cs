            int counter= 0;
            string cadena = "8,5,6,3,4,6,3"
            string[] foto = cadena.Split(',');
            byte[] fotoFinal = new byte[foto.Length];
            foreach (string s in foto)
            {
                fotoFinal[contador] = Convert.ToByte(s);
                counter++;
            }
