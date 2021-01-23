public void Read(blah)
{
    using (var reader = GetReader())
    {
        //read some stuff        
    }
}
public void Read(blah blah)
{
    using (var reader = GetReader())
    {
        //read some different stuff        
    }
}
private BinaryReader GetReader()
{
    //How do I dispose this stream?
    using(FileStream stream = new FileStream(Path, FileMode.Open, FileAccess.Read))
    {
        return new BinaryReader(stream);
    }
}
