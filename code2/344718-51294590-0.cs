        private void moveDirectory(string fuente,string destino)
        {
            if (!System.IO.Directory.Exists(destino))
            {
                System.IO.Directory.CreateDirectory(destino);
            }
            String[] files = Directory.GetFiles(fuente);
            String[] directories = Directory.GetDirectories(fuente);
            foreach (string s in files)
            {
                System.IO.File.Copy(s, Path.Combine(destino,Path.GetFileName(s)), true);     
            }
            foreach(string d in directories)
            {
                moveDirectory(Path.Combine(fuente, Path.GetFileName(d)), Path.Combine(destino, Path.GetFileName(d)));
            }
        }
