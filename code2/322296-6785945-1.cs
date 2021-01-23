foreach (var item in readItems)
                     using (var fileStream = storage.OpenFile(item.FileName, FileMode.Open, FileAccess.Read))
                     {
                         using (var reader = new StreamReader(fileStream))
                         {
                             item.FileName = reader.ReadLine();
                             item.FileText1 = reader.ReadLine();
                             item.RdbText1 = reader.ReadLine();
                         }
                     }
</pre>
