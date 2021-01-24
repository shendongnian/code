class Program
{
    static void Main(string[] args)
    {
        string input_dir = @"env\srv-bext\import-bext\";
        string output_dir = @"env\srv-bext\import-bext\imported\";
        string archive_dir = @"env\srv-bext\import-bext\archive\";
        string[] index = File.ReadAllLines(input_dir + "acontrol.txt");
        string[] prefixes = new string[] {
            "exp_vente_ent_",
            "ctl_",
            "exp_vente_lig_",
            "mvt_",
            "rcp_achat_ent_",
            "rcp_achat_lig_",
            "rec_vente_lig_",
            "rec_vente_ent_"
        };
        string[] extensions = new string[2] {"txt", "top" };
        if (!Directory.Exists(input_dir))
        {
            Console.WriteLine("Err: Input directory doesn't exist.");
            Console.ReadLine();
            return;
        }
        if (!Directory.Exists(output_dir))
            Directory.CreateDirectory(output_dir);
        if (!Directory.Exists(archive_dir))
            Directory.CreateDirectory(archive_dir);
        foreach (string id  in index)
        {
            foreach (string pre in prefixes)
            {
                foreach (string ext in extensions)
                {
                    string filename = pre + id + "." + ext;
                    if (File.Exists(input_dir + filename))
                    {
                        try
                        {
                            File.Copy(input_dir + filename, output_dir + filename);
                            File.Copy(input_dir + filename, archive_dir + filename);
                            File.Delete(input_dir + filename);
                            Console.WriteLine("Info: " + filename + " file processed");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Err: " + e.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Warn: " + filename + " is missing");
                    }
                }
            }
        }
        Console.ReadLine();
    }
}
