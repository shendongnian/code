            var columnHeaders = lines[0];
            var textToReplace = "idn_prod";
            var newText = "idn_prod1";
            var indexToReplace = columnHeaders
                .LastIndexOf("idn_prod");//LastIndex ensures that you pick the second idn_prod
            columnHeaders = columnHeaders
                .Remove(indexToReplace,textToReplace.Length)
                .Insert(indexToReplace, newText);//I'm removing the second idn_prod and replacing it with the updated value.
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(file1))
            {
                sw.WriteLine(columnHeaders);
                foreach (var str in lines.Skip(1))
                {
                    sw.WriteLine(str);
                }
                sw.Flush();
            }
