// not List = ..., List is a class, you need a new instance of a list.
List<Email> list = getList(path, type);
if (list.Count > 0)
{
    // Do Something
}
// [...]
private List<Email> getList(string path, string type)
{
    List<Email> ret = new List<Email>();
    string[] jsonFileList = Directory.GetFiles(path, type + "_*.json");
    if (jsonFileList.Length > 0)
    {
        //read json file
        foreach (string file in jsonFileList)
        {
            if (File.Exists(file))
            {
                // not List.Add(), List is a class, you need to add to the instance of a list.
                ret.Add(JsonConvert.DeserializeObject<ExceptionEmail>(File.ReadAllText(file)));
                // File.Delete(file); // The method shouldn't delete files when it's name is getList, delete them after handling in the calling method.
            }
        }
    }
    return ret;
}
Also you should work on your style.
- Please do use strong types wherever possible. (i.E. no Object)
- Try to avoid static functions and variables unless you need them.
- For readability write the access modifier.
- Variable and argument names should be lower case and constants capitals. Only classes, enums and interfaces, structs, etc. should start with a capital letter.
- Only use reference arguments if you need to. Call by value is default for a reason. (The reason being encapsulation, and avoiding side effects. Also you would expect the function here to alter path if you say it's byref, which it doesn't.)
- getList shouldn't delete files. You wouldn't expect that from a name like that. Delete the files AFTER you processed them in the loop in the calling method.
- please review the difference between classes and objects/instances.
- please review function calls and return values.
