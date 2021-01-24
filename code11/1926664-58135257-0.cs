    Console.Write("Write the file you want to edit ");
    Filename = Console.ReadLine();
    picture = new Bitmap(Filename);
    string NewFilename = Path.GetFileNameWithoutExtension(Filename)
                       + StrToAppend
                       + Path.GetExtension(Filename);
    picture.Save(Newfilename, picture.RawFormat);
