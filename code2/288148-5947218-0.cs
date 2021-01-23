    public void File_To_Text(string filepath)
    {  
      string [] fname;
    
                fname = Directory.GetFiles(filepath, "*.*", SearchOption.AllDirectories).Select(x => Path.GetFileName(x)).ToArray();
                File.WriteAllLines("c:\\images.txt", fname, Encoding.UTF8);
    }
