// WRITE
using (var fileStream = new FileStream("file.bin", FileMode.Append))
{
    Serializer.Serialize(fileStream, OBJ_struct);
}
// READ
using (var fileStream = new FileStream("file.bin", FileMode.Open))
{
    struct_obj str = Serializer.Deserialize<struct_obj >(fileStream);
    for (int num=0;  num < str.arr_currentIndex.Length; num++)
    {
        listBox1.Items.Add(str.arr_currentIndex[num]);
    }
    
}
Thank you those who recommended protobuf!
