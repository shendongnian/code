entity.file.CopyTo(new FileStream(fullPath, FileMode.Create));FileMode.Create)); //Is this last part supposed to be here, because I have never seen a method which works with a semicolon as a parameter separator.
to
//Opens the file
using (FileStream stream = new FileStream(fullPath, FileMode.Create))
{
    //Copies data from entity.file to stream
    entity.file.CopyTo(stream);
}
//File was released (disposed of) thanks to the using statement
After the copy is done, the file is released so other processes will be able to access it.
