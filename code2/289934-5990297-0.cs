            string s = "hello world hello test testing hello .. hello ... test hello";
            string[] value = { "hello" };
            string[] strList = s.Split(value,255,StringSplitOptions.None);
            string newStr = "";
            int replacePos = 4;
            for (int i = 0; i < strList.Length; i++)
            {
                if ((i != replacePos - 1) && (strList.Length != i + 1))
                {
                    newStr += strList[i] + value[0];
                }
                else if (strList.Length != i + 1)
                {
                    newStr += strList[i] + "tree";
                }
            }
