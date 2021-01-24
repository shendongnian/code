                var str = @"LINE 1: hello
    LINE 2: hello
    LINE 1: hello
    LINE 2: hello
    LINE 1: hello
    LINE 2: hello";
            var arr = str.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            string[] arr2 = new string[arr.Count()];
            bool pair = false;
            for (int i = 0; i < arr.Count(); i++)
            {
                if (pair)
                {
                    var index = arr[i].Length;
                    arr2[i] = arr[i].Insert(index, ">\r\n");
                    pair = !pair;
                }
                else
                {
                    arr2[i] = arr[i].Insert(8, "<");
                    pair = !pair;
                }
            }
            string modString = "";
            foreach (var item in arr2)
            {
                modString += item + "\r\n";
            }
            MessageBox.Show(modString);
