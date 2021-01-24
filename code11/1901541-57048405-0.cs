    static void Main(string[] args)
    {
        string full_path = @"D:\steam\steamapps\common\Call of Duty Black Ops III\xanim_export\elfenliedtopfan5_anims\pubg\m1911";
        var dir_1 = System.IO.Path.GetDirectoryName(full_path);
        var dir_2 = System.IO.Path.GetDirectoryName(dir_1);
        var common = System.IO.Path.GetDirectoryName(dir_2);
        var specific = full_path.Substring(common.Length+1);
        Console.WriteLine(specific);
        // "elfenliedtopfan5_anims\pubg\m1911"
    }
